using ApplicationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationWeb.Controllers
{
    public class HomeController : Controller
    {
       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddData(string city,string country , string lat,string lon)
        {
          
                Detail details = new Detail()
                {
                    city_name = city,
                    country_name = country,
                    latitude = lat,
                    longitude = lon,
                };
                new Database().addData(details);
                return RedirectToAction("Index");
         
           
        }


        [HttpGet]
        public IActionResult ShowData()
        {
            var objDetail = new Database().getdetail().ToList();
            return View(objDetail);

        }

   
    }
}
