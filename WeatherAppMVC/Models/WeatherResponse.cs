using System;
using System.Collections.Generic;

namespace WeatherAppMVC.Models
{
    public class WeatherResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GenerationTimeMs { get; set; }
        public int UtcOffsetSeconds { get; set; }
        public string Timezone { get; set; }
        public string TimezoneAbbreviation { get; set; }
        public double Elevation { get; set; }  // Changed from int to double
        public HourlyUnits hourly_units { get; set; }
        public HourlyDto hourly { get; set; }
    }

    public class HourlyUnits
    {
        public string Time { get; set; }
        public string Temperature_2m { get; set; }
    }

    public class HourlyDto
    {
        public List<DateTime> Time { get; set; } = new List<DateTime>();  // Initialized list to avoid null reference
        public List<double> Temperature_2m { get; set; } = new List<double>();  // Initialized list to avoid null reference
    }
}
