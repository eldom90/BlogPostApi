using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostApp.Services.ViewModel.Post;
using BlogPostData.Model;

namespace BlogPostApp.Services.Interfaces
{
    public interface IPostRepository
    {
        List<Post> Get();
        void Create(PostViewModel entity);
        void Delete(string slug);
        void Update(PostViewModel entity,string slugId);
    }
}
