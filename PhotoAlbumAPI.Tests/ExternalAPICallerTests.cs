using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhotoAlbumAPI.Tests
{
    [TestClass]
    public class ExternalAPICallerTests
    {
        [TestMethod]
        public async Task TestCallValidAPIAsync()
        {
            var caller = new Models.ExternalAPICaller();
            var result = await caller.CallExternalAPI("http://jsonplaceholder.typicode.com/users");
            Assert.IsNotNull(result);
        }
    }
}
