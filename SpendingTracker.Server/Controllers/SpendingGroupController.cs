using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.Server.DTO;
using SpendingTracker.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpendingController : ControllerBase
    {
        private ApplicationContext _context;
        public SpendingController(ApplicationContext context)
        {
            _context = context;
        }

        // api/spending/userID
        [HttpGet("{userID}")]
        public IEnumerable<SpendingGroup> GetSpendings(Guid userID)
        {
            return _context.SpendingGroups.Include(x => x.Spendings).AsNoTracking().Where(x => x.UserID == userID);
        }

        // api/spending/create
        [HttpPost("create")]
        public async Task<IActionResult> AddSpendingGroup([FromBody] SpendingGroupCreate spendingGroup)
        {
            try
            {
                var date = DateTime.Now;
                var minDate = DateTime.Now;

                var group = new SpendingGroup(Guid.NewGuid());

                group.Spendings = new List<Spending>();
                foreach (var sp in spendingGroup.Spendings)
                {
                    var spending = new Spending(Guid.NewGuid())
                    {
                        GroupID = group.ObjectID,
                        Description = sp.Description,
                        Date = sp.Date ?? date,
                        Sum = sp.Sum
                    };

                    group.Spendings.Add(spending);
                    if (minDate < date)
                    {
                        minDate = date;
                    }
                }

                group.Name = spendingGroup.Name;
                group.CreatedDate = minDate;
                group.UpdatedDate = minDate;
                group.UserID = spendingGroup.UserID;

                _context.SpendingGroups.Add(group);
                _context.Spendings.AddRange(group.Spendings);
                await _context.SaveChangesAsync();

                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }

        // api/spending/add/{spendingGroupID}
        [HttpPost("add/{spendingGroupID}")]
        public async Task<IActionResult> AddSpendingToGroup(Guid spendingGroupID, [FromBody]SpendingCreate spending)
        {
            try
            {
                var group = await _context.SpendingGroups.FirstOrDefaultAsync(x => x.ObjectID == spendingGroupID);
                if (group != null)
                {
                    var created = new Spending(Guid.NewGuid())
                    {
                        GroupID = spendingGroupID,
                        Description = spending.Description,
                        Date = spending.Date ?? DateTime.Now,
                        Sum = spending.Sum
                    };
                    group.Spendings.Add(created);
                    _context.Spendings.Add(created);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}
