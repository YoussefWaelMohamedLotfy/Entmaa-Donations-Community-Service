using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs;
using Entmaa_Web_Services.DTOs.Posts;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class PostController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Organizations/{id}/news")]
        [HttpGet]
        public IHttpActionResult GetOrganizationNews(int id)
        {
            var news = _unit.Posts.GetOrganizationNews(id);

            if (news == null)
                return NotFound();

            var dto = news.Select(_mapper.Map<Post, GetOrganizationNewsDTO>);
            return Json(dto);
        }

        [Route("api/Contributors/{id}/news")]
        [HttpGet]
        public IHttpActionResult GetRecommendedNews(int id)
        {
            var news = _unit.Posts.GetOrganizationNews(id);

            if (news == null)
                return NotFound();

            var dto = news.Select(_mapper.Map<Post, GetOrganizationNewsDTO>);
            return Json(dto);
        }

        [Route("api/Organizations/{id}/news")]
        [HttpPost]
        public IHttpActionResult CreateNewsPost(int id, CreatePostDTO postDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var organization = _unit.Organizations.GetOrganization(id);

            if (organization == null)
                return NotFound();

            try
            {
                var post = _mapper.Map<Post>(postDTO);
                post.PostedBy = organization.ID;
                post.TimePosted = DateTime.Now;

                _unit.Posts.Add(post);

                //var tagsinDb = _unit.Tags.GetTags((List<TagDTO>)postDTO.Tags);

                //foreach (var tag in tagsinDb)
                //{
                //    ((HashSet<Tag>)post.Tags).Add(tag);
                //}

                _unit.CompleteWork();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Json(new { message = "Successfully Created !" });
        }

        [Route("api/Organizations/{id}/news/{postId}")]
        [HttpPatch]
        public IHttpActionResult EditNewsPost(int id, int postId, CreatePostDTO postDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var post = _unit.Posts.GetPost(postId);

            if (post == null)
                return NotFound();

            var tagsinDb = _unit.Tags.GetTags((List<TagDTO>)postDTO.Tags);

            foreach (var tag in tagsinDb)
            {
                ((HashSet<Tag>)post.Tags).Add(tag);
            }

            _mapper.Map(postDTO, post);
            _unit.CompleteWork();

            return Json(new { message = "Successfully Edited !" });
        }

        [Route("api/Organizations/{id}/news/{postId}")]
        [HttpDelete]
        public IHttpActionResult DeleteNewsPost(int id, int postId)
        {
            var post = _unit.Posts.Get(postId);

            if (post == null)
                return NotFound();

            _unit.Posts.Delete(post);
            _unit.CompleteWork();

            return Json(new { message = "Successfully Deleted !" });
        }

    }
}
