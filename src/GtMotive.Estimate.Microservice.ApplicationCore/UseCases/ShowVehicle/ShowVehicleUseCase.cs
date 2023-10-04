using System;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.Domain.Errors;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ShowVehicle
{
    /// <summary>
    /// use case class.
    /// </summary>
    public class ShowVehicleUseCase : IShowVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">vehicleRepository.</param>
        /// <param name="showVehicleOutPutPort">showVehicleOutPutPort.</param>
        public ShowVehicleUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        /// <summary>
        /// executes the use case.
        /// </summary>
        /// <param name="input">ShowVehicleInput.</param>
        /// <returns>Vehicles.</returns>
        public async Task<ErrorOr<ShowVehicleOutput>> Execute(ShowVehicleInput input)
        {
            if (input is not null)
            {
                var vehicles = await _vehicleRepository.GetVehiclesFromFleet(input.IdFleet);

                var outPutVehicles = new ShowVehicleOutput(vehicles);

                return outPutVehicles;
            }

            return Errors.Renting.VehicleDoesNotExists;
        }
    }
}
