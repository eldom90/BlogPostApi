using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPostApp.API.Services.Helpers;
using BlogPostApp.Services.Interfaces;
using BlogPostApp.Services.ViewModel.Tag;
using BlogPostData.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : Controller
    {   
        private ITagRepository tagRepositroy;

        public TagsController( ITagRepository _tagRepositroy)
        {            
            tagRepositroy = _tagRepositroy;
        }

        [HttpGet]
        public JsonResult Tags()
        {
            var _list = tagRepositroy.Get();
            List<string> _listTag = new List<string>();

            TagDTO _listTags = new TagDTO();

            foreach (var item in _list)
            {
                _listTag.Add(item.tagName);
            }

            _listTags.tagNames = _listTag;

            return Json(_listTags);
        }
    }
}
