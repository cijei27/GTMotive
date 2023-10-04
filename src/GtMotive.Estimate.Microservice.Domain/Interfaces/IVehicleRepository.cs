using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Renting;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    ///  Represents an interface for all the vehicle's actions.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Retrieves a Vehicle.
        /// </summary>
        /// <param name="idVehicle">The unique identifier of the vehicle.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<VehicleEntity> GetVehicleAsync(Guid idVehicle);

        /// <summary>
        /// Creates a vehicle.
        /// </summary>
        /// <param name="vehicleEntity">All the values for creating a vehicle.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicleEntity);

        /// <summary>
        /// Update the state of the vehicle.
        /// </summary>
        /// <param name="idVehicle">The unique identifier of the vehicle.</param>
        /// <param name="isRenting">Show if the vehicle is renting or not.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateStatusOfRentingAsync(Guid idVehicle, bool isRenting);

        /// <summary>
        /// Retrieves a list of all available vehicles within a specified fleet.
        /// </summary>
        /// <param name="idFleet">The unique identifier of the fleet to retrieve available vehicles from.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, returning a list of available vehicles.</returns>
        Task<List<VehicleEntity>> GetVehiclesFromFleet(Guid idFleet);
    }
}
