using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostApp.Services.ViewModel.Tag;
using BlogPostData.Model;

namespace BlogPostApp.Services.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> Get();
        void Create(TagViewModel entity);
        void Update(Tag entity);
    }
}
