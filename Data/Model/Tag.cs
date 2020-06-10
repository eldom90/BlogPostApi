using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPostData.Model
{
    public class Tag
    {
        [Key]
        public int tagId { get; set; }
        public string tagName { get; set; }
        public string postId { get; set; }

    }
}