using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.Posts;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class InteractionController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public InteractionController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Posts/{postId}/reacts")]
        [HttpGet]
        public IHttpActionResult GetWhoReacted(int postId)
        {
            var post = _unit.Posts.GetPost(postId);

            if (post == null)
                return NotFound();

            var usersReactedDTO = post.UsersReacted.Select(_mapper.Map<User, UsersReactedDTO>);
            return Json(usersReactedDTO);
        }

        [Route("api/Posts/{postId}/comments")]
        [HttpPost]
        public IHttpActionResult CommentOnPost(int postId, CommentDTO commentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var comment = _mapper.Map<PostComment>(commentDTO);
            comment.Comment = commentDTO.CommentText;
            comment.DateCommented = DateTime.Now;
            comment.PostID = postId;

            _unit.Comments.Add(comment);
            _unit.CompleteWork();

            return Ok();
        }

        [Route("api/Posts/{postId}/reacts/{userId}")]
        [HttpPost]
        public IHttpActionResult ReactOnPost(int postId, int userId)
        {
            var user = _unit.Contributors.Get(userId);
            var post = _unit.Posts.GetPost(postId);

            if (user == null || post == null)
                return NotFound();

            if (post.UsersReacted.Contains(user))
                return Json(new { message = "User already reacted." });

            post.UsersReacted.Add(user);
            _unit.CompleteWork();

            return Ok();
        }

        [Route("api/Posts/{postId}/reacts/{userId}")]
        [HttpDelete]
        public IHttpActionResult RemoveReactOnPost(int postId, int userId)
        {
            var user = _unit.Contributors.Get(userId);
            var post = _unit.Posts.GetPost(postId);

            if (user == null || post == null)
                return NotFound();

            if (!post.UsersReacted.Contains(user))
                return Json(new { message = "User did not reacted at first." });

            post.UsersReacted.Remove(user);
            _unit.CompleteWork();

            return Ok();
        }

    }
}
