using HotelListing_API.Contracts;
using HotelListing_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApplication1.Data;

namespace HotelListing_API.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;

        public CountriesRepository(HotelListingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.CountryId == id);

        }
    }
}
