using FluentValidation;

namespace Crm.Application.Ticket.Create
{
    /// <summary>
    /// handle validator of ticket
    /// in this validator title and username and description aren't empty or null
    /// </summary>
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {

            RuleFor(r=> r.Title)
                .NotEmpty().WithMessage("موضوع نباید خالی باشد")
                .NotNull().WithMessage("موضوع نباید خالی باشد");
            RuleFor(r => r.UsernameReciver)
                .NotEmpty().WithMessage("لطفا نام کاربری گیرنده را وارد نماید")
                .NotNull().WithMessage("لطفا نام کاربری گیرنده را وارد نماید");
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("لطفا شرح تیکت را وارد نماید")
                .NotNull().WithMessage("لطفا شرح تیکت را وارد نماید");
        }
    }
}
