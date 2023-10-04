using System;
using System.Threading.Tasks;
using ErrorOr;
using GtMotive.Estimate.Microservice.Domain.Errors;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Use case for returning a rented vehicle.
    /// </summary>
    public class ReturnVehicleUseCase : IReturnVehicleUseCase
    {
        private readonly IRentingRepository _rentingRepository;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentingRepository">rentingRepository.</param>
        /// <param name="vehicleRepository">vehicleRepository.</param>
        /// <param name="returnVehicleOutPutPort">returnVehicleOutPutPort.</param>
        public ReturnVehicleUseCase(IRentingRepository rentingRepository, IVehicleRepository vehicleRepository)
        {
            _rentingRepository = rentingRepository ?? throw new ArgumentNullException(nameof(rentingRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        }

        /// <summary>
        /// Execute the use case.
        /// </summary>
        /// <param name="input">ReturnVehicleOutput.</param>
        /// <returns><see cref="ReturnVehicleOutput"/>.</returns>
        public async Task<ErrorOr<ReturnVehicleOutput>> Execute(ReturnVehicleInput input)
        {
            if (input is not null)
            {
                var hasRenting = await _rentingRepository.GetRentingAsync(input.IdRenting);

                if (hasRenting is null)
                {
                    return Errors.Renting.RentingIsNotAvailable;
                }

                await _rentingRepository.UpdateRentingToCompleteAsync(input.IdRenting);
                await _vehicleRepository.UpdateStatusOfRentingAsync(hasRenting.IdVehicle, false);

                var returnVehicleOutput = new ReturnVehicleOutput("Renting updated");
                return returnVehicleOutput;
            }

            return Errors.Renting.RentingIsNotAvailable;
        }
    }
}
