using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsManager : ControllerBase
    {
        private ICommentService _commentService;

        public CommentsManager(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("getallcomment")]
        public IActionResult GetAllComments()
        {
            var result = _commentService.GetList();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycommentid/{id}")]
        public IActionResult GetByCommentId(int id)
        {
            var result = _commentService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addcomment")]
        public IActionResult AddComment(Comment comment)
        {
            _commentService.Add(comment);
            return Ok("category added");
        }

        [HttpDelete("deletecomment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.GetById(id);
            _commentService.Delete(value);
            return Ok("category deleted");
        }

        [HttpPost("updatecomment")]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentService.Update(comment);
            return Ok("comment updated");
        }
    }
}
