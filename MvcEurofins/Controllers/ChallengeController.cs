using Microsoft.AspNetCore.Mvc;
using MvcEurofins.Models;
using System.Collections.Generic;

namespace MvcEurofins.Controllers
{
    public class ChallengeController : Controller
    {
        public IActionResult Index()
        {
            return View(new ChallengeModel());
        }

        [HttpPost]
        public IActionResult Index(ChallengeModel model)
        {
            if (model.Start > model.End)
            {
                ModelState.AddModelError(string.Empty, "Start number must be less than or equal to End number.");
                return View(model);
            }

            var numbers = GetNumbers(model.Start, model.End);
            ViewBag.Numbers = numbers;
            return View(model);
        }

        private List<string> GetNumbers(int start, int end)
        {
            var numbers = new List<string>();
            for (int i = start; i <= end; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    numbers.Add("Eurofins");
                }
                else if (i % 3 == 0)
                {
                    numbers.Add("Three");
                }
                else if (i % 5 == 0)
                {
                    numbers.Add("Five");
                }
                else
                {
                    numbers.Add(i.ToString());
                }
            }
            return numbers;
        }
    }
}
