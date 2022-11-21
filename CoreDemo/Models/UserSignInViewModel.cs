using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string password { get; set; }
    }
}
