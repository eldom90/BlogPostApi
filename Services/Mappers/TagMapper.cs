using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostApp.Services.ViewModel.Tag;
using BlogPostData.Model;
using Microsoft.IdentityModel.Tokens;

namespace BlogPostApp.Services.Mappers
{
    public class TagMapper
    {
        public TagMapper()
        {

        }

        public TagViewModel Map(Tag tag)
        {
            return new TagViewModel()
            {
               
                postId= tag.postId,
                tagName = tag.tagName
            };
        }

        public Tag Map(TagViewModel tag)
        {
            return new Tag()
            {
                postId= tag.postId,
                tagName = tag.tagName
            };
        }
    }
}
