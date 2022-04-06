using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.Server.DTO;
using SpendingTracker.ServiceLayer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }

        // GET api/user
        [HttpGet]
        public IQueryable<SystemUserShortInfo> Get()
        {
            return _context.Users.Select(x => new SystemUserShortInfo(x));
        }

        // GET api/user/89711b9a-cb37-4e76-8882-f73272b124fe
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUserFullInfo>> Get(Guid id)
        {
            var user = await _context.Users.Include(x => x.Spendings).Include(x => x.Categories).FirstOrDefaultAsync(x => x.ObjectID == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new SystemUserFullInfo(user));
            }
        }

        // api/user/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SystemUserCreate user)
        {
            try
            {
                Guid curID = user.ObjectID ?? Guid.NewGuid();
                var createdUser = new SystemUser(curID)
                {
                    Login = user.Login,
                    Password = user.Password
                };
                _context.Users.Add(createdUser);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}