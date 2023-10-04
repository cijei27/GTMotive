using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.RentingVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ReturnVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.ShowVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [Route("Renting")]
    public class RentingController : ApiController
    {
        private readonly ISender _mediator;

        public RentingController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Add a vehicle in the fleet.
        /// </summary>
        /// <param name="command">CreateVehicleCommand.</param>
        /// <returns>ok or problema.</returns>
        [HttpPost]
        [Route("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                vehicle => Ok(vehicle),
                errors => Problem(errors));
        }

        /// <summary>
        /// Show all the vehicles.
        /// </summary>
        /// <param name="command">ShowVehicleCommand.</param>
        /// <returns>vehicleResponse.</returns>
        [HttpPost]
        [Route("ShowVehicles")]
        public async Task<IActionResult> ShowVehicles([FromBody] ShowVehicleCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                vehicles => Ok(vehicles),
                errors => Problem(errors));
        }

        /// <summary>
        /// Renting a vehicle.
        /// </summary>
        /// <param name="command">RentingVehicleCommand.</param>
        /// <returns>RentingResponse.</returns>
        [HttpPost]
        [Route("RentingVehicle")]
        public async Task<IActionResult> RentingVehicle([FromBody] RentingVehicleCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                renting => Ok(renting),
                errors => Problem(errors));
        }

        /// <summary>
        /// Return when the renting is completed.
        /// </summary>
        /// <param name="command">ReturnVehicleCommand.</param>
        /// <returns>Message.</returns>
        [HttpPut]
        [Route("ReturnVehicle")]
        public async Task<IActionResult> ReturnVehicle([FromBody] ReturnVehicleCommand command)
        {
            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}
