using FizzBuzz2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzz2MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult FBPage()
        {
            /*Calling FizzBuzz here is called instansiation.
             Youre accessing the FizzBuzz class from the Model and creating a copy of it*/
            FizzBuzz model = new();

            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FBPage(FizzBuzz fizzbuzz)
        {
            List<string> fbItems = new();

            bool fizz;
            bool buzz;

            for (int i = 1; i <= 100; i++)
            {
                fizz = (i % fizzbuzz.FizzValue == 0);
                buzz = (i % fizzbuzz.BuzzValue == 0);

                if (fizz == true && buzz == true)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (fizz == true)
                {
                    fbItems.Add("Fizz");
                }
                else if (buzz == true)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }
            fizzbuzz.Result = fbItems;

            return View(fizzbuzz);
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