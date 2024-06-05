using FluentValidation;

namespace Crm.Application.Ticket.Create
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {

            RuleFor(r=> r.Title)
                .NotEmpty().WithMessage("موضوع نباید خالی باشد")
                .NotNull().WithMessage("موضوع نباید خالی باشد");
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("لطفا شرح تیکت را وارد نماید")
                .NotNull().WithMessage("لطفا شرح تیکت را وارد نماید");
        }
    }
}
