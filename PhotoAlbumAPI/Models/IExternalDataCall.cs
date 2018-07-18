using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbumAPI.Models
{
    public interface IExternalDataCall
    {
        Task<JArray> CallExternalAPI(string uri);
    }
}
