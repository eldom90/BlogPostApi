using BlogPostApp.Services.Interfaces;
using BlogPostApp.Services.Mappers;
using BlogPostApp.Services.ViewModel.Tag;
using BlogPostData.Context;
using BlogPostData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApp.Services.Repositories
{
    public class TagRepositroy : ITagRepository
    {
        private readonly ApplicationDbContext _blogpostContext;

        public TagRepositroy(ApplicationDbContext blogpostContext)
        {
            _blogpostContext = blogpostContext;
        
        }

        public void Create(TagViewModel entity)
        {
            TagMapper _tagMapper = new TagMapper();

            Tag tag = _tagMapper.Map(entity);
            _blogpostContext.Tag.Add(tag);
            _blogpostContext.SaveChanges();      
        }

        public List<Tag> Get()
        {
            return _blogpostContext.Tag.AsNoTracking().ToList();
        }

        public void Update(Tag entity)
        {
            _blogpostContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _blogpostContext.SaveChanges();
        }
    }
}
