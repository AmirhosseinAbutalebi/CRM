using FluentValidation;

namespace Crm.Application.User.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(f => f.Password)
                .NotEmpty().WithMessage("کلمه عبور نباید خالی باشد")
                .NotNull().WithMessage("لطفا کلمه عبور را وارد نماید")
                .MinimumLength(6).WithMessage("کلمه عبور باید بشتر از 6 کارکتر باشد");
            RuleFor(f => f.UserName)
                .NotEmpty().WithMessage("نام کاربری نباید خالی باشد")
                .NotNull().WithMessage("لطفا نام کاربری را وارد نماید")
                .MinimumLength(4).WithMessage("نام کاربری باید بشتر از 4 کارکتر باشد");
        }
    }
}
