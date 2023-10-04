using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ShowVehicle
{
    public class ShowVehicleCommandValidator : AbstractValidator<ShowVehicleCommand>
    {
        public ShowVehicleCommandValidator()
        {
            RuleFor(r => r.IdFleet).NotEmpty();
        }
    }
}
