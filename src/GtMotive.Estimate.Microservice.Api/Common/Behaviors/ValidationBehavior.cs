using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
 where TRequest : IRequest<TResponse>
 where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest> validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

            var errors = validatorResult.Errors
                        .ConvertAll(validationFailure => Error.Validation(
                            validationFailure.PropertyName,
                            validationFailure.ErrorMessage));

            return (dynamic)errors;
        }
    }
}
