using Microsoft.AspNetCore.Mvc;

namespace SD.Controllers
{
    [Route("api/[controller]")]
    public class IssueController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json("zdarova");
        }
    }
}