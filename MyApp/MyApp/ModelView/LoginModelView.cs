using System.ComponentModel.DataAnnotations;

namespace MyApp.ModelView
{
    public class LoginModelView
    {
        [Required]
        [DataType(DataType.Text)]

        public string UserName { get; set; }
   
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool  RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
