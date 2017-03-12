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
        private readonly IUserStore<AgentModel> _storage;
        public UserController(IUserStore<AgentModel> storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            CrmAgentStore _store = new CrmAgentStore(new DescStorage("Server=localhost;Port=3306;Database=2x2CRM;Uid=root;Pwd=1234;SslMode=None;"));
            List<AgentModel> s =  _store.Users.ToList();
            return Json(s);
            
        }

    }
}
