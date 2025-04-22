using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace HotelListing_API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options) : base(options)
        {
              
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
