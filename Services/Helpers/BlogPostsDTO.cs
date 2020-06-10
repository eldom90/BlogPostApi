using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApp.API.Services.Helpers
{
    public class BlogPostsDTO
    {
        public List<PostDTO> blogPosts { get; set; }
        public float countPost { get; set; }
    }
}
