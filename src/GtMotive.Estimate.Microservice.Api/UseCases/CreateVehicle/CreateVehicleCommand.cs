using System;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle
{
    public record CreateVehicleCommand(
        Guid IdFleet,
        string PlateNumber,
        string Model,
        string Brand,
        DateTime Registration,
        bool Renting) : IRequest<ErrorOr<CreateVehicleOutput>>;
}
