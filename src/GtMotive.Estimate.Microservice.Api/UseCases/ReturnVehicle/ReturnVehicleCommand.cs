using System;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle
{
    public record ReturnVehicleCommand(
        Guid IdRenting) : IRequest<ErrorOr<ReturnVehicleOutput>>;
}
