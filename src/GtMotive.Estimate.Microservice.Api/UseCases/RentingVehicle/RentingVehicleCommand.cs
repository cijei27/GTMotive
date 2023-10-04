using System;
using ErrorOr;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentingVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.RentingVehicle
{
    public record RentingVehicleCommand(
       Guid IdVehicle,
       string DNICustomer,
       DateTime StartRenting,
       DateTime FinishRenting) : IRequest<ErrorOr<RentingVehicleOutput>>;
}
