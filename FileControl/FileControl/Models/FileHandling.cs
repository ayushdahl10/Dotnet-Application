using BusinessModel;
using DataLayer;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileControl.Models
{
    public class FileHandling
    {
 

        public Task upload_file(IFormFile file, IWebHostEnvironment webHostEnvironment1)
        {
            //uploading path
            string upload = Path.Combine(webHostEnvironment1.WebRootPath, "upload");
            //creates a directory if it doesnt exist
            if (!Directory.Exists(upload))
            {
                Directory.CreateDirectory(upload);
            }

                if (file.Length > 0)
                {
                    string filepath = Path.Combine(upload, file.FileName);

                    using (Stream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fileStream);
                    }
                
            }
            return Task.CompletedTask;

        }


        public void import(string path)
        {
            List<Item> items = new List<Item>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read();
                        while(reader.Read())
                        {
                        
                        items.Add(new Item() {
                            Item_Name = reader.GetValue(0).ToString(),
                            Item_Quantity =(Decimal)reader.GetDouble(1),
                            Amount = (Decimal)reader.GetDouble(2),
                            Discount = (Decimal)reader.GetDouble(3),
                            Item_Rate =(Decimal)reader.GetDouble(4),
                        }); 

                        }
                    
                }
            }
            foreach(var item in items)
            {
                new ItemDao().AddItem(item);
            }


        }


      




    }
}
