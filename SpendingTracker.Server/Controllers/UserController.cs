using Microsoft.AspNetCore.Mvc;
using SpendingTracker.Model.DTO;
using SpendingTracker.Server.Repository;
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
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET api/user
        [HttpGet]
        public async Task<IEnumerable<SystemUserInfo>> Get()
        {
            var res = await _userRepository.GetAllAsync();
            return res.Select(x => new SystemUserInfo(x));
        }

        // GET api/user/89711b9a-cb37-4e76-8882-f73272b124fe
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUserInfo>> Get(Guid id)
        {
            var user = await _userRepository.GetObjectByIDAsync(id);
            if (user == null)
                return NotFound();
            return new ObjectResult(new SystemUserInfo(user));
        }
    }
}
