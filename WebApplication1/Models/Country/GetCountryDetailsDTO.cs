namespace HotelListing_API.Models.Country
{
    public class GetCountryDetailsDTO
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<HotelDTO> Hotels { get; set; }   
    }
}
