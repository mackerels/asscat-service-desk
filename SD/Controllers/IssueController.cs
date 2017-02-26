using System;
using Microsoft.AspNetCore.Mvc;
using SD.Storage;

namespace SD.Controllers
{
    [Route("api/[controller]")]
    public class IssueController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new DescStorage().Issues);
        }
    }
}