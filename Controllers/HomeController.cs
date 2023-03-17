using FizzBuzz_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzz_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FizzBuzzPage()
        {
            FizzBuzz model = new FizzBuzz();

            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FizzBuzzPage(FizzBuzz model)
        {
            List<string> fbItems = new List<string>();

            bool Fizz;
            bool Buzz;

            for (int i = 1; i <= 100; i++)
            {
                Fizz = (i % model.FizzValue == 0);
                Buzz = (i % model.BuzzValue == 0);

                if (Fizz == true && Buzz == true)
                {
                    fbItems.Add("FizzBuzz");
                }else if(Fizz == true)
                {
                    fbItems.Add("Fizz");
                }else if(Buzz == true)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }

            model.Results = fbItems;

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}