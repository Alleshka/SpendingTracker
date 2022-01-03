using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendingTracker.Model;
using SpendingTracker.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingTracker.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ApplicationContext db;
        public UserController(ApplicationContext context)
        {
            db = context;
        }

        // GET api/user
        [HttpGet]
        public async Task<IEnumerable<SystemUserInfo>> Get()
        {
            return await db.Users.Select(x => new SystemUserInfo(x)).ToListAsync();
        }

        // GET api/user/89711b9a-cb37-4e76-8882-f73272b124fe
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUser>> Get(Guid id)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.ObjectID == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(new SystemUserInfo(user));
        }
    }
}
