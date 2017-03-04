using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Storage;
using Storage.Models;

namespace SD.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class IssueController : Controller
    {
        private readonly IServiceDeskStorage _storage;
        private readonly UserManager<AgentModel> _manager;

        public IssueController(IServiceDeskStorage storage, UserManager<AgentModel> manager)
        {
            _storage = storage;
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _manager.GetUserAsync(User);
            return Json(_storage.Issues.Where(iss => iss.Owner.Id == user.Id));
        }
    }
}