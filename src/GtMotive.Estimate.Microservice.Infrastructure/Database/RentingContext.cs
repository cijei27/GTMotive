using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.Data;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Primitives;
using GtMotive.Estimate.Microservice.Domain.Renting;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static GtMotive.Estimate.Microservice.Domain.Errors.Errors;

namespace GtMotive.Estimate.Microservice.Infrastructure.Database
{
    public class RentingContext : DbContext, IRentingContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public RentingContext(DbContextOptions<RentingContext> options, IPublisher publisher)
            : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        /// <summary>
        /// Gets or sets vehicles.
        /// </summary>
        public DbSet<VehicleEntity> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets renting.
        /// </summary>
        public DbSet<RentingEntity> Renting { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is not null)
            {
                modelBuilder.Entity<VehicleEntity>(build =>
                {
                    build.HasKey(entry => entry.IdVehicle);
                    build.Property(entry => entry.IdFleet);
                    build.Property(entry => entry.PlateNumber);
                    build.Property(entry => entry.Model);
                    build.Property(entry => entry.Brand);
                    build.Property(entry => entry.Registration);
                    build.Property(entry => entry.Renting);
                    build.Property(entry => entry.IdVehicle).ValueGeneratedOnAdd();
                });

                modelBuilder.Entity<RentingEntity>(build =>
                {
                    build.HasKey(entry => entry.IdRenting);
                    build.Property(entry => entry.IdVehicle);
                    build.Property(entry => entry.DNICustomer);
                    build.Property(entry => entry.StartRenting);
                    build.Property(entry => entry.FinishRenting);
                    build.Property(entry => entry.IdRenting).ValueGeneratedOnAdd();
                });

                modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentingContext).Assembly);
            }
        }
    }
}
