using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public class ReturnVehicleCommandValidator : AbstractValidator<ReturnVehicleCommand>
    {
        public ReturnVehicleCommandValidator()
        {
            RuleFor(r => r.IdRenting).NotEmpty();
        }
    }
}
