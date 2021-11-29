using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.ModelView
{
    public class ImageModelView
    {
        public IFormFile Image { get; set; }
    }
}
