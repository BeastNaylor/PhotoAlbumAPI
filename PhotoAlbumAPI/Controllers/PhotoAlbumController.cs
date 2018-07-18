using PhotoAlbumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhotoAlbumAPI.Controllers
{
    public class PhotoAlbumController : ApiController
    {
        IExternalDataCall _caller;

        public PhotoAlbumController()
        {
            _caller = new ExternalAPICaller();
        }

        public PhotoAlbumController(IExternalDataCall caller)
        {
            _caller = caller;
        }

        public async Task<ICollection<Album>> GetAllPhotoAlbums()
        {
            return await GetAllCombinedAlbums();
        }

        public async Task<ICollection<Album>> GetPhotoAlbumsForUser(int id)
        {
            ICollection<Album> albums = await GetAllCombinedAlbums();
            var userAlbums = albums.Where(a => a.userId == id).ToArray();
            return userAlbums;
        }

        private async Task<ICollection<Album>> GetAllCombinedAlbums()
        {
            var result = await _caller.CallExternalAPI("http://jsonplaceholder.typicode.com/albums");
            var albums = result.ToObject<ICollection<Album>>();
            return null;
        }
    }
}