using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoAlbumAPI.Models
{
    public class Album
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public IEnumerable<Photo> photos { get; set; }
    }
}