using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Renting;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Represents an interface for a repository responsible for renting data.
    /// </summary>
    public interface IRentingRepository
    {
        /// <summary>
        /// Retrieves a renting.
        /// </summary>
        /// <param name="idRenting">The unique identifier of the renting.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<RentingEntity> GetRentingAsync(Guid idRenting);

        /// <summary>
        /// Creates a renting.
        /// </summary>
        /// <param name="rentingEntity">All the values for creating a renting.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<RentingEntity> CreateRentingAsync(RentingEntity rentingEntity);

        /// <summary>
        /// Update the state of the renting.
        /// </summary>
        /// <param name="idRenting">The unique identifier of the renting.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateRentingToCompleteAsync(Guid idRenting);

        /// <summary>
        /// Return if the renting is active.
        /// </summary>
        /// <param name="dniCustomer">Cuestomer's DNI.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> RentingIsActive(string dniCustomer);
    }
}
