using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Contracts.V1;

namespace TaskTracker.Controllers.V1
{
    public class TaskController : Controller
    {
        [HttpGet(ApiRoutes.Tasks.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(new { Name = "Conor", Age = 22 });
        }
    }
}
