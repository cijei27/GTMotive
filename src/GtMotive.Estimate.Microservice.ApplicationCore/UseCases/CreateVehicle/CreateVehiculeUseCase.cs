using System;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.Domain.Errors;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Renting;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Use case for creating a vehicle.
    /// </summary>
    public class CreateVehiculeUseCase : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehiculeUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">vehicleRepository.</param>
        /// <param name="createVehicleOutputPort">createVehicleOutputPort.</param>
        public CreateVehiculeUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">input for creating a vehicle.</param>
        /// <returns>CreateVehicleOutput.</returns>
        public async Task<ErrorOr<CreateVehicleOutput>> Execute(CreateVehicleInput input)
        {
            if (input is not null)
            {
                if (input.Registration < DateTime.UtcNow.AddYears(-5))
                {
                    return Errors.Renting.RentingCarNotAvailable;
                }

                var vehicle = new VehicleEntity(Guid.NewGuid(), input.IdFleet, input.PlateNumber, input.Model, input.Brand, input.Registration, input.Renting);
                var responseVehicle = await _vehicleRepository.CreateVehicleAsync(vehicle);
                var outputVehicle = new CreateVehicleOutput(responseVehicle.IdVehicle, responseVehicle.IdFleet, responseVehicle.PlateNumber, responseVehicle.Model, responseVehicle.Brand, responseVehicle.Registration, responseVehicle.Renting);
                return outputVehicle;
            }

            return Errors.Renting.VehicleDoesNotExists;
        }
    }
}
