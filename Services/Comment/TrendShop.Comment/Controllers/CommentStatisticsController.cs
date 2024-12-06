using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrendShop.Comment.Context;

namespace TrendShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticsController : ControllerBase
    {
        private readonly CommentContext _context;
        public CommentStatisticsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            int values = await _context.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
