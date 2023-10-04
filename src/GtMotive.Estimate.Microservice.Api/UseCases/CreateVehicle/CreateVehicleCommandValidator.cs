using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(r => r.Model).NotEmpty();
            RuleFor(r => r.PlateNumber).NotEmpty();
            RuleFor(r => r.Registration).NotEmpty();
            RuleFor(r => r.Renting).NotEmpty();
        }
    }
}
