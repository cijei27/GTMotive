﻿using System.Threading;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Unit Of Work. Should only be used by Use Cases.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Applies all database changes.
        /// </summary>
        /// <param name="cancellationToken">CancellationToken by default.</param>
        /// <returns>Number of affected rows.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
