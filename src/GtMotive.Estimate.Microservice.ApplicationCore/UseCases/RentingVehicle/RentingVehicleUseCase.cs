using System;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.Domain.Errors;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Renting;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentingVehicle
{
    /// <summary>
    /// use case for renting a vehicule.
    /// </summary>
    public class RentingVehicleUseCase : IRentingVehicleUseCase
    {
        private readonly IRentingRepository _rentingRepository;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentingVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentingRepository">rentingRepository.</param>
        /// <param name="vehicleRepository">vehicleRepository.</param>
        /// <param name="rentingVehicleOutPutPort">rentingVehicleOutPutPort.</param>
        public RentingVehicleUseCase(IRentingRepository rentingRepository, IVehicleRepository vehicleRepository)
        {
            _rentingRepository = rentingRepository ?? throw new ArgumentNullException(nameof(rentingRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">input for renting a vehicle.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<ErrorOr<RentingVehicleOutput>> Execute(RentingVehicleInput input)
        {
            if (input is not null)
            {
                var vehicle = await _vehicleRepository.GetVehicleAsync(input.IdVehicle);
                if (vehicle is null)
                {
                    return Errors.Renting.VehicleDoesNotExists;
                }

                var hasActiveRental = await _rentingRepository.RentingIsActive(input.DNICustomer);

                if (hasActiveRental)
                {
                    return Errors.Renting.CustomerHasRentingActive;
                }

                var renting = new RentingEntity(Guid.NewGuid(), input.IdVehicle, input.DNICustomer, input.StartRenting, input.FinishRenting);
                var responseRenting = await _rentingRepository.CreateRentingAsync(renting);
                var outputRenting = new RentingVehicleOutput(responseRenting.IdRenting, responseRenting.IdVehicle, responseRenting.DNICustomer, responseRenting.StartRenting, responseRenting.FinishRenting);

                return outputRenting;
            }

            return Errors.Renting.RentingNotCreated;
        }
    }
}
