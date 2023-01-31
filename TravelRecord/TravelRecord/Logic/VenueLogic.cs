using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TravelRecord.Helpers;
using TravelRecord.Model;

namespace TravelRecord.Logic
{
    public  class VenueLogic
    {
        public static async Task<List<Venue>> GetVenues(double lat, double @long)
        {

            // Pass the handler to httpclient(from you are calling api)
            var venues = new List<Venue>();
            var url = Venue.GenerateUrl(lat, @long);



            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
            }


            return venues;
        }
    }
}
