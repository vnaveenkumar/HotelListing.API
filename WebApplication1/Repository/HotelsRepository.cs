using HotelListing_API.Contracts;
using HotelListing_API.Data;
using WebApplication1.Data;

namespace HotelListing_API.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        public HotelsRepository(HotelListingDbContext context) : base(context)
        {
        }
    }
}
