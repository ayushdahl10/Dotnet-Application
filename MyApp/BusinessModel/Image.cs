using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessModel
{
    public class Image
    {
        public int id { get; set; }

        [DataType(DataType.ImageUrl)]
        public string imageUrl { get; set; }
    }
}
