using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessModel
{
    public class Customer:Gender
    {
        public int CustomerID { get; set; }

        [Required]
        
        public string UserName { get; set; }

  

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public long Number { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DOB { get; set; }

        [DataType(DataType.DateTime)]
        public string JoinDate { get; set; }

    }
}
