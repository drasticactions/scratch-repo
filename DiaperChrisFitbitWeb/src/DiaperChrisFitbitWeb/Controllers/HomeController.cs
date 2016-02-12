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

        public IActionResult UrbanLegends()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/urbanlegends.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult DevilsShare()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/devilsshare.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult HorrificHorror()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/horrifichorror.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult RedLake()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/redlake.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult Taken()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/taken.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult Lucius()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/luciusII.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
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

        public IActionResult TheInterview()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/theinterview.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult ClownHouse()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/clownhouse.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult Slenderman()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/slenderman.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }

        public IActionResult Despair()
        {
            var mybonesJson = System.IO.File.ReadAllText(_hostEnvironment.WebRootPath + "/js/despair.json");
            var result = JsonConvert.DeserializeObject<List<FitbitRate>>(mybonesJson);
            return View(new GameFitbitModel()
            {
                FitbitResults = result
            });
        }
    }
}
