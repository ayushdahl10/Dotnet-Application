using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessModel
{
    public class Gender
    {
        [Required]
        [Display(Name ="Gender")]
        public string _Gender { get; set; }
        
    }
}
