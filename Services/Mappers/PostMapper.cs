using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostApp.Services.ViewModel.Post;
using BlogPostData.Model;
using Microsoft.IdentityModel.Tokens;


namespace BlogPostApp.Services.Mappers
{
    public class PostMapper
    {   
        public PostMapper()
        {
          
        }

        public PostViewModel Map(Post post)
        {
            return new PostViewModel()
            {
                slug = post.slug,
                title = post.title, 
                description = post.description,
                body = post.body,
                createdAt = post.createdAt,
                updatedAt = post.updatedAt
            };
        }

        public Post Map(PostViewModel post)
        {
            return new Post()
            {
                slug = post.slug,
                title = post.title,
                description = post.description,
                body = post.body,
                createdAt = post.createdAt,
                updatedAt = post.updatedAt
            };
        }
    }
}
