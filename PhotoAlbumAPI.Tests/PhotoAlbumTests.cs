using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbumAPI.Controllers;
using PhotoAlbumAPI.Models;

namespace PhotoAlbumAPI.Tests
{
    [TestClass]
    public class PhotoAlbumTests
    {
        PhotoAlbumController _controller;

        [TestInitialize]
        public void Init()
        {
            IExternalDataCall fakeCaller = new FakeDataCaller();
            _controller = new PhotoAlbumController(fakeCaller);

        }

        [TestMethod]
        public void TestGetAllPhotoAlbums()
        {
            ICollection<Album> albums = _controller.GetAllPhotoAlbums().Result;
            Assert.AreEqual(4, albums.Count);
        }

        [TestMethod]
        public void TestGetPhotoAlbumsForUser()
        {
            var albums = _controller.GetPhotoAlbumsForUser(2).Result;
            var photos = albums.SelectMany(a => a.photos).ToList();
            Assert.AreEqual(2, albums.Count);
            Assert.AreEqual(4, photos.Count);
        }

        [TestMethod]
        public void TestGetPhotoAlbumsForBadUser()
        {
            var result = _controller.GetPhotoAlbumsForUser(-1).Result;
            Assert.AreEqual(0, result.Count);
        }
    }
}
