using System;
using System.Linq;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers;

[ApiController]
public class CommentsController(CommentsRepository commentsRepository) : ControllerBase
{
    [HttpGet("api/news/{newsId:guid}/comments")]
    public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
    {
        var comments = commentsRepository.GetComments(newsId)
            .Select(c => new CommentDto { User = c.User, Value = c.Value })
            .ToArray();

        return new CommentsDto { NewsId = newsId, Comments = comments };
    }
}