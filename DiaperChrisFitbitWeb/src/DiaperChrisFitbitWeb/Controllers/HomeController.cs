using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiaperChrisFitbitWeb.Model;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DiaperChrisFitbitWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostEnvironment;

        public HomeController(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyBones()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/mybones.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }
    }
}
