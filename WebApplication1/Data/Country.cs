﻿namespace WebApplication1.Data
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
