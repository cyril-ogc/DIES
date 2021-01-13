using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIES.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DIES.Demo.Web
{
    public class HomeController : Controller
    {
        private readonly IFooService _fooService;

        public HomeController(IFooService fooService) => _fooService = fooService;

        // GET: /<controller>/
        public IActionResult Index()
        {
            return Ok(_fooService.GetSomething());
        }
    }
}
