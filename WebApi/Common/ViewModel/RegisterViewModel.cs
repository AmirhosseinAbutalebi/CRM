using Crm.Domain.UserAgg.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Common.ViewModel
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نماید")]
        public string Username { get; set; }

        [Required(ErrorMessage = "کلمه عبور الزامی می باشد")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار کلمه عبور الزامی می باشد")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        [Compare(nameof(Password), ErrorMessage = "کلمه های عبور وارد شده یکسان نمی باشند")]
        public string ConfirmPassword { get; set; }
        public LevelUser Role { get; set; }
    }
}
