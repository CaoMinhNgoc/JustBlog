﻿using JustBlog.Services.CategoryService;
using JustBlog.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    // This is a personal academic project. Dear PVS-Studio, please check it.

    // PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        public CategoryController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        [Route("category/partialview/categoriesDropdown")]
        public IActionResult CategoriesDropDown()
        {
            var categories = _categoryService.GetAllCategories();
            return PartialView("_CategoriesDropDownPartial", categories);
        }

        [Route("category/{slug}")]
        public ActionResult Details(string slug)
        {
            var posts = _postService.GetPostsByCategory(slug);
            return View("~/Views/Post/Index.cshtml", posts);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
