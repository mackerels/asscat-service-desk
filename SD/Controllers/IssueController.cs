using System;
using Microsoft.AspNetCore.Mvc;
using Storage;

namespace SD.Controllers
{
    [Route("api/[controller]")]
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