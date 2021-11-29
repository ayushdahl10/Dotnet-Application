using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Upload
    {
        

        public Task upload_file(IFormFile file , IWebHostEnvironment webHostEnvironment1)
        {
            //uploading path
            string upload = Path.Combine(webHostEnvironment1.WebRootPath, "upload");
            //creates a directory if it doesnt exist
            if (!Directory.Exists(upload))
            {
                Directory.CreateDirectory(upload);
            }

            if (file.FileName.EndsWith(".png") || file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".pdf") )
            {
                if (file.Length > 0)
                {
                    string filepath = Path.Combine(upload, file.FileName);

                    using (Stream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }
                return Task.CompletedTask;
            
        }

    }
}

