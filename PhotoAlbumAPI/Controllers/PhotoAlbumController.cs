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
            var albums = (await _caller.CallExternalAPI("http://jsonplaceholder.typicode.com/albums")).ToObject<ICollection<Album>>();
            var photos = (await _caller.CallExternalAPI("http://jsonplaceholder.typicode.com/photos")).ToObject<ICollection<Photo>>();
            //now we have both album and photos, need to set the photo property of the album to the relevant list of photos
            foreach (Album album in albums)
            {
                album.photos = photos.Where(photo => photo.albumId == album.id).ToList();
            }
            return albums;

        }
    }
}