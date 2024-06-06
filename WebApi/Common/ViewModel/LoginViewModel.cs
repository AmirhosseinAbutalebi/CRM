using System.ComponentModel.DataAnnotations;

namespace WebApi.Common.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نماید")]
        public string Username { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی می باشد")]
        public string Password { get; set; }
    }
}
