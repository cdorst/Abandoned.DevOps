using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOps.Abstractions.Platforms.AspNetCore.Controllers.Mvc
{
    public class ListController : Controller
    {
        public IActionResult Index() => View();
    }
}
