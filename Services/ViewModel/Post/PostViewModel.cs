using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostApp.Services.ViewModel.Post
{
    public class PostViewModel
    {
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string body { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}