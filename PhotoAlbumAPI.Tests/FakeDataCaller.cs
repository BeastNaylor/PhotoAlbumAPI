using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PhotoAlbumAPI.Models;

namespace PhotoAlbumAPI.Tests
{
    class FakeDataCaller : IExternalDataCall
    {
        public async Task<JArray> CallExternalAPI(string uri)
        {
            JArray results = null;
            switch(uri)
            {
                case "http://jsonplaceholder.typicode.com/albums":
                    var albums = new List<Album>();
                    albums.Add(new Album() { id = 1, userId = 1, title = "Sample 1" });
                    albums.Add(new Album() { id = 2, userId = 1, title = "Sample 2" });
                    albums.Add(new Album() { id = 3, userId = 2, title = "Sample 3" });
                    albums.Add(new Album() { id = 4, userId = 2, title = "Sample 4" });
                    results = JArray.FromObject(albums);
                    break;
                case "http://jsonplaceholder.typicode.com/photos":
                    var photo = new List<Photo>();
                    photo.Add(new Photo() { id = 1, albumId = 1, title = "Photo 1",url = "Sample Url 1", thumbnailUrl = "Sample Thumbnail 1" });
                    photo.Add(new Photo() { id = 2, albumId = 1, title = "Photo 2", url = "Sample Url 2", thumbnailUrl = "Sample Thumbnail 2" });
                    photo.Add(new Photo() { id = 3, albumId = 2, title = "Photo 3", url = "Sample Url 3", thumbnailUrl = "Sample Thumbnail 3" });
                    photo.Add(new Photo() { id = 4, albumId = 2, title = "Photo 4", url = "Sample Url 4", thumbnailUrl = "Sample Thumbnail 4" });
                    photo.Add(new Photo() { id = 5, albumId = 3, title = "Photo 5", url = "Sample Url 5", thumbnailUrl = "Sample Thumbnail 5" });
                    photo.Add(new Photo() { id = 6, albumId = 3, title = "Photo 6", url = "Sample Url 6", thumbnailUrl = "Sample Thumbnail 6" });
                    photo.Add(new Photo() { id = 7, albumId = 4, title = "Photo 7", url = "Sample Url 7", thumbnailUrl = "Sample Thumbnail 7" });
                    photo.Add(new Photo() { id = 8, albumId = 4, title = "Photo 8", url = "Sample Url 8", thumbnailUrl = "Sample Thumbnail 8" });
                    results = JArray.FromObject(photo);
                    break;
            }
            return results;
        }
    }
}
