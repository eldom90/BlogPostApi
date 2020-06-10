using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlogPostApp.API.Services.Helpers;
using BlogPostApp.Services.Interfaces;
using BlogPostApp.Services.ViewModel.Post;
using BlogPostApp.Services.ViewModel.Tag;
using BlogPostData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;

namespace BlogPostApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostRepository postRepository;
        private ITagRepository tagRepositroy;
        private BlogPostsDTO listBlogPostsItems;
        private BlogPostDTO listBlogPostItem;
        private bool bloglistitems=false;

        public PostController(IPostRepository _postRepository, ITagRepository _tagRepositroy)
        {
            postRepository = _postRepository;
            tagRepositroy = _tagRepositroy;

            LoadPosts();
        }

        private void LoadPosts()
        {
            List<PostDTO> _listPost = new List<PostDTO>();

            var listPostAll = postRepository.Get().ToList();

            foreach (var itemPost in listPostAll)
            {
                PostDTO _postItem = new PostDTO();

                _postItem.slug = itemPost.slug;
                _postItem.title = itemPost.title;
                _postItem.description = itemPost.description;
                _postItem.body = itemPost.body;
                _postItem.createdAt = itemPost.createdAt;
                _postItem.updatedAt = itemPost.updatedAt;

                var listTagAll = tagRepositroy.Get().Where(t => t.postId == itemPost.slug).ToList();

                _postItem.tagList = new List<string>();

                foreach (var itemTag in listTagAll)
                {
                    _postItem.tagList.Add(itemTag.tagName);
                }

                _listPost.Add(_postItem);
            }

            if (_listPost.Count > 1)
            {
                BlogPostsDTO _listBlogPost = new BlogPostsDTO();
                _listBlogPost.countPost = _listPost.Count;
                _listBlogPost.blogPosts = _listPost;

                listBlogPostsItems =_listBlogPost;
                bloglistitems = true;
            }
            else
            {
                BlogPostDTO _listBlogPost = new BlogPostDTO();
                _listBlogPost.blogPost = _listPost.FirstOrDefault();

                listBlogPostItem = _listBlogPost;
            }
        }

        [HttpGet]
        public JsonResult Posts(string tag)
        {            
            if (bloglistitems == true)
            {
                BlogPostsDTO _blogPostsTemp = new BlogPostsDTO();
                BlogPostDTO _blogPostTemp = new BlogPostDTO();

                BlogPostsDTO _listTemp = listBlogPostsItems;

                var _list = _listTemp.blogPosts.OrderByDescending(b=>b.updatedAt);

                if (tag != null)
                {
                    _list = _listTemp.blogPosts.Where(b => b.tagList.Any(s => s.Equals(tag, StringComparison.OrdinalIgnoreCase))).OrderByDescending(b => b.updatedAt);

                    if (_list.Count() > 1)
                    {
                        _blogPostsTemp.countPost = _list.Count();
                        _blogPostsTemp.blogPosts = _list.ToList();

                        return Json(_blogPostsTemp);
                    }
                    else
                    {
                        _blogPostTemp.blogPost = _list.FirstOrDefault();

                        return Json(_blogPostTemp);
                    }
                }

                _blogPostsTemp.countPost = _list.Count();
                _blogPostsTemp.blogPosts = _list.ToList();

                return Json(_blogPostsTemp);
            }
            else
            {
                return Json(listBlogPostItem);
            }        
        }

        [HttpGet("{id}")]
        public JsonResult Post(string id)
        {
            if (bloglistitems == true)
            {
                BlogPostsDTO _listTemp = listBlogPostsItems;

                BlogPostDTO _list = new BlogPostDTO();

                if (id != null)
                {
                    _list.blogPost = _listTemp.blogPosts.Where(b => b.slug == id).FirstOrDefault();
                }

                return Json(_list);
            }
            else
            {
                return Json(listBlogPostItem);
            }
        }

        [HttpPost]
        public void Create([FromBody] BlogPostDTO _post)
        {
            var tagList = _post.blogPost.tagList;
            var postItem = _post.blogPost;

            var cfpToAddSlug = FriendlyUrlHelper.GetFriendlyTitle(_post.blogPost.title);
            var i = 0;
            var j = 0;
           
            while (postRepository.Get().Any(cfp => cfp.slug == cfpToAddSlug))
            {
                if (j >= 1)
                    cfpToAddSlug = cfpToAddSlug.Remove(cfpToAddSlug.Length - 2);

                cfpToAddSlug = $"{cfpToAddSlug}-{++i}";

                ++j;
            }

            PostViewModel _postTemp = new PostViewModel();

            _postTemp.slug = cfpToAddSlug;

            _postTemp.title = _post.blogPost.title;
            _postTemp.description = _post.blogPost.description;
            _postTemp.body = _post.blogPost.body;
            _postTemp.createdAt = DateTime.Now;
            _postTemp.updatedAt = DateTime.Now;

            postRepository.Create(_postTemp);

            if (tagList != null)
            {
                foreach (var item in tagList)
                {
                    TagViewModel _tagTemp = new TagViewModel();
                    _tagTemp.tagName = item;
                    _tagTemp.postId = cfpToAddSlug;
                    tagRepositroy.Create(_tagTemp);
                }
            }
        }

        [HttpPut("{id}")]
        public void Update(string id , [FromBody] BlogPostDTO _post)
        {
            if (id != null)
            {
                var postItem = _post.blogPost;

                PostViewModel _postTemp = new PostViewModel();

                if (_post.blogPost.title != null)
                {
                    var cfpToAddSlug = FriendlyUrlHelper.GetFriendlyTitle(_post.blogPost.title);
                    var i = 0;
                    var j = 0;

                    while (postRepository.Get().Any(cfp => cfp.slug == cfpToAddSlug))
                    {
                        if (j >= 1)
                            cfpToAddSlug = cfpToAddSlug.Remove(cfpToAddSlug.Length - 2);

                        cfpToAddSlug = $"{cfpToAddSlug}-{++i}";

                        ++j;
                    }

                    _postTemp.title = _post.blogPost.title;

                    _postTemp.slug = cfpToAddSlug;
                }

                _postTemp.description = _post.blogPost.description;
                _postTemp.body = _post.blogPost.body;

                postRepository.Update(_postTemp, id);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            if(id != null)
            postRepository.Delete(id);
        }
    }
}
