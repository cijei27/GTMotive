using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Renting;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Database.Repositories
{
    public class RentingRepository : IRentingRepository
    {
        private readonly RentingContext _context;

        public RentingRepository(RentingContext context)
        {
            _context = context;
        }

        public async Task<RentingEntity> CreateRentingAsync(RentingEntity rentingEntity)
        {
            _context.Renting.Add(rentingEntity);

            await _context.SaveChangesAsync();

            return rentingEntity;
        }

        public async Task<RentingEntity> GetRentingAsync(Guid idRenting)
        {
            return await _context.Renting.FirstOrDefaultAsync(r => r.IdRenting == idRenting);
        }

        public async Task<bool> RentingIsActive(string dniCustomer)
        {
            var rentingActive = await _context.Renting.FirstOrDefaultAsync(r => r.DNICustomer == dniCustomer);

            return rentingActive != null;
        }

        public async Task UpdateRentingToCompleteAsync(Guid idRenting)
        {
            var renting = await _context.Renting.FirstOrDefaultAsync(r => r.IdRenting == idRenting);

            _context.Renting.Remove(renting);

            await _context.SaveChangesAsync();
        }
    }
}
