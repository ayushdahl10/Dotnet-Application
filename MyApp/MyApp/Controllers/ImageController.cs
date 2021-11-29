using BusinessModel;
using DataLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.ModelView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Controllers
{
 
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment1;

        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment1 = webHostEnvironment;
        }


        public IActionResult Index()
        {

            return View();
        }

        [Authorize]
        [HttpGet]
        [Route("upload")]
        public IActionResult Upload()
        {
            return View();
        }



        [HttpPost]
        [Route("upload")]
        [ActionName("Upload")]
        public IActionResult Upload_img([FromForm] ImageModelView modelView)
        {

            Image url = new Image();
            new Upload().upload_file(modelView.Image, webHostEnvironment1);
            if (modelView.Image.FileName.EndsWith(".jpg") || modelView.Image.FileName.EndsWith(".png"))
            {
                url.imageUrl = "/upload/" + modelView.Image.FileName;
                new CustomerDAO().AddUrl(url);
            }
            return RedirectToAction("Index");
        }





    }
}

