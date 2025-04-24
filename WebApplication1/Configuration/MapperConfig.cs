using AutoMapper;
using HotelListing_API.Models.Country;
using WebApplication1.Data;

namespace HotelListing_API.Configuration
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<Country,CreateCountryDTO>().ReverseMap();
            CreateMap<Country,CountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Country,UpdateCountryDTO>().ReverseMap(); 
        }
    }
}
