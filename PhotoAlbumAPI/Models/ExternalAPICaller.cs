using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PhotoAlbumAPI.Models
{
    public class ExternalAPICaller : IExternalDataCall
    {
        public async Task<JArray> CallExternalAPI(string uri)
        {
            JArray results;
            //call external API and return results
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(new Uri(uri));
                results = JArray.Parse(response);
            }
            return results;
        }
    }
}