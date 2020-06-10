using BlogPostApp.API.Services.Helpers;
using BlogPostApp.Services.Interfaces;
using BlogPostApp.Services.Mappers;
using BlogPostApp.Services.ViewModel.Post;
using BlogPostData.Context;
using BlogPostData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostApp.Services.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _blogpostContext;
        private ITagRepository _tagRepositroy;

        public PostRepository(ApplicationDbContext blogpostContext, ITagRepository tagRepositroy)
        {
            _blogpostContext = blogpostContext;
            _tagRepositroy = tagRepositroy;
        }

        public void Create(PostViewModel entity)
        {
            PostMapper _postMapper = new PostMapper();

            Post post = _postMapper.Map(entity);
            _blogpostContext.Post.Add(post);
            _blogpostContext.SaveChanges();
           
        }

        public void Delete(string slug)
        {
            var posts = _blogpostContext.Post.Where(p => p.slug == slug).FirstOrDefault();

            List<Tag> tag = _blogpostContext.Tag.Where(t => t.postId == posts.slug).ToList();
            foreach (var item in tag)
            {
                _blogpostContext.Tag.Remove(item);
                _blogpostContext.SaveChanges();
            }

            _blogpostContext.Post.Remove(posts);
            _blogpostContext.SaveChanges();
        }

        public List<Post> Get()
        {
            return _blogpostContext.Post.ToList();
        }

        public void Update(PostViewModel entity, string slugId)
        {
            List<Tag> tag = _blogpostContext.Tag.Where(t => t.postId == slugId).ToList();
            foreach (var item in tag)
            {
                Tag tagTemp = item;
                tagTemp.postId = entity.slug;
                _tagRepositroy.Update(tagTemp);
            }

            Post postentity = _blogpostContext.Post.Where(p => p.slug == slugId).FirstOrDefault();
            if (entity.title != null)
            {
                postentity.slug = entity.slug;
                postentity.title = entity.title;
            }
            postentity.description = entity.description;
            postentity.body = entity.body;
            postentity.updatedAt = DateTime.Now;

            _blogpostContext.Entry(postentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _blogpostContext.SaveChanges();
        }
    }
}
