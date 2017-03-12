using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SD.SelfIdentity;
using Storage;
using Storage.Models;

namespace SD.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AgentModel> _manager;

        public UserController(UserManager<AgentModel> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Json(_manager.Users);
        }

    }
}
