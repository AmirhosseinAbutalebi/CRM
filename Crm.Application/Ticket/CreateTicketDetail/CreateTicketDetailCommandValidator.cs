using FluentValidation;

namespace Crm.Application.Ticket.CreateTicketDetail
{
    public class CreateTicketDetailCommandValidator : AbstractValidator<CreateTicketDetailCommand>
    {
        public CreateTicketDetailCommandValidator()
        {
            RuleFor(r => r.Text)
                .NotEmpty().WithMessage("لطفا پیام تیکت را وارد نماید")
                .NotNull().WithMessage("لطفا پیام تیکت را وارد نماید");
        }
    }
}
