using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Renting;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Data
{
    /// <summary>
    /// Context of renting.
    /// </summary>
    public interface IRentingContext
    {
        /// <summary>
        /// Gets or sets vehicles.
        /// </summary>
        public DbSet<VehicleEntity> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets renting.
        /// </summary>
        public DbSet<RentingEntity> Renting { get; set; }

        /// <summary>
        /// SavechangesAsync.
        /// </summary>
        /// <param name="cancellationToken">CancelationToken.</param>
        /// <returns>int.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
