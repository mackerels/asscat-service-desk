using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage;

namespace SD.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class IssueController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new DescStorage(
                "Server=localhost;Port=3306;Database=2x2CRM;Uid=root;Pwd=123;SslMode=None;"
            ).Issues);
        }
    }
}