using FluentValidation;
using MediatR;
using System.Text;

namespace Crm.Application.Shared
{
    /// <summary>
    /// for set validation in project with piplinebehavior
    /// </summary>
    /// <typeparam name="TRequest">generic type of request validator</typeparam>
    /// <typeparam name="TResponse">generic type of response validator</typeparam>
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var error = _validator
                .Select(e => e.Validate(request))
                .SelectMany(request => request.Errors)
                .Where(r => r != null);

            if (error.Any())
            {
                var errorMessage = new StringBuilder();
                foreach (var message in error)
                {
                    errorMessage.AppendLine(message.ErrorMessage);
                }
                throw new InvalidDataException(errorMessage.ToString());
            }

            var response = await next();

            return response;
        }
    }
}
