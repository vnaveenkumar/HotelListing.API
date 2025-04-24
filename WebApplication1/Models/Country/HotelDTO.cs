﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing_API.Models.Country
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int CountryId { get; set; }
    }
}