using System;
using System.Collections.Generic;
using System.Text;
using TravelRecord.Helpers;

namespace TravelRecord.Model
{
    public class Venue
    {
        public static string GenerateUrl(double lat, double @long)
        {
           return String.Format(Constants.URL, lat, @long, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Today.ToString("yyyyMMdd"));
        }
    }
}
