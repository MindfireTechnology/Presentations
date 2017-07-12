using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    public class PTController : Controller
    {
        public IActionResult Test(string id)
        {
            var pt = new PeriodicTable();
            var result = pt.SearchWord(id);

            string resultStr = string.Empty;
            foreach(string str in result.Keys)
            {
                resultStr += "[" + str + "] - " + result[str] + "\n";
            }

            return Content(resultStr);
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test.Model
{
    public class PTModel
    {
        public ValueList Result { get; set; } 

        [Required]
        public string Name { get; set; } 
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Model;

namespace Test.Controllers
{
    public class PTController : Controller
    {
        public IActionResult Test(string id)
        {
            var pt = new PeriodicTable();
            var result = pt.SearchWord(id);

            string resultStr = string.Empty;
            foreach(string str in result.Keys)
            {
                resultStr += "[" + str + "] - " + result[str] + "\n";
            }

            return Content(resultStr);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PTModel model)
        {
            var pt = new PeriodicTable();
            model.Result = pt.SearchWord(model.Name);
            return View(model);
        }
    }
}



