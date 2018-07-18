using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbumAPI.Models;

namespace PhotoAlbumAPI.Tests
{
    [TestClass]
    public class PhotoAlbumTests
    {
        [TestMethod]
        public void TestGetAllPhotoAlbums()
        {
            var controller = new Controllers.PhotoAlbumController();
            ICollection<Album> albums = controller.GetAllPhotoAlbums().Result;
            Assert.AreEqual(albums.Count, 10);
        }

        [TestMethod]
        public void TestGetPhotoAlbumsForUser()
        {
            var controller = new Controllers.PhotoAlbumController();
            var albums = controller.GetPhotoAlbumsForUser(5).Result as OkNegotiatedContentResult<ICollection<Album>>; ;
            Assert.AreEqual(albums.Content.Count, 2);
        }

        [TestMethod]
        public void TestGetPhotoAlbumsForBadUser()
        {
            var controller = new Controllers.PhotoAlbumController();
            var result = controller.GetPhotoAlbumsForUser(-1);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
