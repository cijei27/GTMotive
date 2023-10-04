using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Renting;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Database.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly RentingContext _context;

        public VehicleRepository(RentingContext context)
        {
            _context = context;
        }

        public async Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicleEntity)
        {
            _context.Vehicles.Add(vehicleEntity);

            await _context.SaveChangesAsync();

            return vehicleEntity;
        }

        public async Task<VehicleEntity> GetVehicleAsync(Guid idVehicle)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(r => r.IdVehicle == idVehicle);
        }

        public async Task<List<VehicleEntity>> GetVehiclesFromFleet(Guid idFleet)
        {
            return await _context.Vehicles.Where(r => r.Renting == false && r.IdFleet == idFleet).ToListAsync();
        }

        public async Task UpdateStatusOfRentingAsync(Guid idVehicle, bool isRenting)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(r => r.IdVehicle == idVehicle);

            vehicle.Renting = isRenting;

            _context.Update(vehicle);

            await _context.SaveChangesAsync();
        }
    }
}
