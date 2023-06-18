﻿using JustBlog.Core.Entities;
using JustBlog.Services.TagService;
using JustBlog.ViewModels.Others;
using JustBlog.ViewModels.Tag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Authorize(policy: "Get")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Get")]
        public IActionResult GetPagedTags(int page = 1, int pageSize = 10)
        {
            var tags = _tagService.GetPagedTags(page, pageSize);
            var total = _tagService.CountAllTags();
            var dataTable = new DataTableViewModel
            {
                Action = "GetPagedTags",
                Controller = "Tag",
                Total = total,
                Page = page,
                LastPage = (int)Math.Ceiling((double)total / pageSize),
                PageSize = pageSize,
                Columns = new string[] { "Id", "Name", "Slug", "Description" },
                Data = tags.Select(tag =>
                    new Dictionary<string, string>
                    {
                        { "Id", tag.Id.ToString() },
                        { "Name", tag.Name },
                        { "Slug", tag.UrlSlug },
                        { "Description", tag.Description }
                    }
                ).ToList()
            };
            return PartialView("_DataTablePartial", dataTable);
        }

        [Authorize(policy: "Get")]
        public IActionResult Details(int id)
        {
            var tagDetails = _tagService.GetDetails(id);
            if (tagDetails == null)
                return View("NotFound");
            return View(tagDetails);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Create(NewTagViewModel newTag)
        {
            if (ModelState.IsValid && _tagService.Add(newTag))
                return Redirect("/Admin/Tag");
            return View(newTag);

        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Edit(int id)
        {
            var editTag = _tagService.GetEditTag(id);
            if (editTag == null)
                return View("NotFound");
            return View(editTag);
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Edit(EditTagViewModel editTag)
        {
            if (ModelState.IsValid)
            {
                if (_tagService.Update(editTag))
                    ViewBag.Message = "Update successfully!";
                else
                    ViewBag.Message = "Update failed!";
            }

            return View(editTag);
        }

        [Authorize(policy: "Delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_tagService.Delete(id))
                return StatusCode(200);
            return View("NotFound");
        }
    }
}
