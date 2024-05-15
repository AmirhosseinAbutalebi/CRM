
using FluentValidation;

namespace Crm.Application.TicketDetail.Create
{
    /// <summary>
    /// handle validator of ticketdetail
    /// in this validator text isn't empty or null
    /// </summary>
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
