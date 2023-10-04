using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentingVehicle
{
    public class RentingVehicleCommandValidator : AbstractValidator<RentingVehicleCommand>
    {
        public RentingVehicleCommandValidator()
        {
            RuleFor(r => r.DNICustomer).NotEmpty();
            RuleFor(r => r.IdVehicle).NotEmpty();
            RuleFor(r => r.StartRenting).NotEmpty();
            RuleFor(r => r.FinishRenting).NotEmpty();
        }
    }
}
