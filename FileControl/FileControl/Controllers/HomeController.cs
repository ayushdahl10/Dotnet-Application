using BusinessModel;
using DataLayer;
using FileControl.Models;
using FileControl.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment1;
        public  HomeController(IWebHostEnvironment webHostEnvironment)
        {
            webHostEnvironment1 = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] ItemModelView objItem)
        {
            
            new FileHandling().upload_file(objItem.Item, webHostEnvironment1);
            string path = "wwwroot/upload/" + objItem.Item.FileName;
            new FileHandling().import(path);
            return RedirectToAction("Index");
        }

        
        public IActionResult export()
        {


            List<Item> objItems = new ItemDao().GetAllItem();
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("items");
                var Customerstyle = xlPackage.Workbook.Styles.CreateNamedStyle("customerStyle");
                Customerstyle.Style.Font.UnderLine = true;
                Customerstyle.Style.Font.Color.SetColor(Color.Black);

                var startRow = 5;
                var row = startRow;
             
                worksheet.Cells["A1"].Value = "Name";
                worksheet.Cells["B1"].Value = "Quantity";
                worksheet.Cells["C1"].Value = "Amount";
                worksheet.Cells["D1"].Value = "Discount";
                worksheet.Cells["E1"].Value = "Rate";

                row = 2;
                foreach (var item in objItems)
                {
                    worksheet.Cells[row, 1].Value = item.Item_Name;
                    worksheet.Cells[row, 2].Value = item.Item_Quantity;
                    worksheet.Cells[row, 3].Value = item.Amount;
                    worksheet.Cells[row, 4].Value = item.Discount;
                    worksheet.Cells[row, 5].Value = item.Item_Rate;
                    row++;
                }

                xlPackage.Workbook.Properties.Title = "Items";

                xlPackage.Save();


            }

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "item.xlsx");



        }

    }
}
