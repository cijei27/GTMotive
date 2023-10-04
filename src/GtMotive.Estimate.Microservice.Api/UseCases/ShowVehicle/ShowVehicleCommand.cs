using System;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ShowVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ShowVehicle
{
    public record ShowVehicleCommand(
        Guid IdFleet) : IRequest<ErrorOr<ShowVehicleOutput>>;
}
