using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "kullanıcı zorunlu")]
        public string Username { get; set; }
        [Required(ErrorMessage = "şifre zorunlu")]
        public string Password { get; set; }
    }
}