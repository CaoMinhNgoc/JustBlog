﻿using JustBlog.Repositories.Infrastructure;
using JustBlog.Services.CommentService;
using JustBlog.Services.PostService;
using JustBlog.ViewModels;
using JustBlog.ViewModels.Comment;
using JustBlog.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using JustBlog.ViewModels.Others;
using Microsoft.AspNetCore.Authorization;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        public CommentController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        [Authorize(policy: "Get")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Get")]
        public IActionResult GetPagedComments(int page, int pageSize)
        {
            var comments = _commentService.GetPagedComments(page, pageSize);
            var total = _commentService.CountAllComments();
            var dataTable = new DataTableViewModel
            {
                Action = "GetPagedComments",
                Controller = "Comment",
                Total = total,
                Page = page,
                LastPage = (int)Math.Ceiling((double)total / pageSize),
                PageSize = pageSize,
                Columns = new string[] { "Id", "Comment header", "Name", "Email", "Posted at" },
                Data = comments.Select(comment =>
                    new Dictionary<string, string>
                    {
                        { "Id", comment.Id.ToString() },
                        { "Comment header", comment.CommentHeader.ToString() },
                        { "Name", comment.Name },
                        { "Email", comment.Email },
                        { "Posted at", comment.CommentTime.FriendlyFormat() }
                    }
                ).ToList()
            };
            return PartialView("_DataTablePartial", dataTable);
        }

        [Authorize(policy: "Get")]
        public IActionResult Details(int id)
        {
            var commentDetails = _commentService.GetDetails(id);
            return View(commentDetails);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Create()
        {
            ViewBag.Posts = _postService.GetAllPosts();
            return View();
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Create(NewCommentViewModel newComment)
        {
            if (ModelState.IsValid && _commentService.Add(newComment))
                return Redirect("/Admin/Comment");
            ViewBag.Posts = _postService.GetAllPosts();
            return View(newComment);

        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Edit(int id)
        {
            var editComment = _commentService.GetEditComment(id);
            if (editComment == null)
                return View("NotFound");

            ViewBag.Posts = _postService.GetAllPosts();
            return View(editComment);
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Edit(EditCommentViewModel editComment)
        {
            if (ModelState.IsValid)
            {
                if (_commentService.Update(editComment))
                    ViewBag.Message = "Update comment successfully";
                else
                    ViewBag.Message = "Update comment failed";
            }

            ViewBag.Posts = _postService.GetAllPosts();
            return View(editComment);

        }

        [Authorize(policy: "Delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_commentService.Delete(id))
                return StatusCode(200);
            return View("NotFound");
        }
    }
}
