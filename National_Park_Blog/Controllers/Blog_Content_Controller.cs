﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using National_Park_Blog.Models;
using National_Park_Blog.Repositories;

namespace National_Park_Blog.Controllers
{
    public class Blog_Content_Controller : Controller
    {
        readonly IRepository<Blog_Content> blogContentRepo;

        public Blog_Content_Controller(IRepository<Blog_Content> blogContentRepo)
        {
            this.blogContentRepo = blogContentRepo;
        }
        public ViewResult Index()
        {
            var model = blogContentRepo.GetAll();
            return View(model);
        }
        public ViewResult Details()
        {
            var model = blogContentRepo.GetAll();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public Microsoft.AspNetCore.Mvc.ActionResult Create(Blog_Content blog_Content)
        {
            blog_Content.BlogContentDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                blogContentRepo.Create(blog_Content);
                return RedirectToAction("Details", "National_Parks", new { id = blog_Content.Id });
            }

            return View(blog_Content);
        }
        [HttpGet]
        public ViewResult Update()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Update(int id)
        {
            Blog_Content blog_Content = blogContentRepo.GetById(id);
            blog_Content.BlogContentDate = DateTime.Now;
            return View(blog_Content);
        }
        [HttpGet]
        public ViewResult Delete(int id)
        {
            Blog_Content blog_Content = blogContentRepo.GetById(id);
            return View(blog_Content);
        }
        [HttpPost]
        public ActionResult Delete(Blog_Content blog_Content)
        {
            if (ModelState.IsValid)
            {
                int Id = blog_Content.Id;

                blogContentRepo.Delete(blog_Content);

                return RedirectToAction("Details", "National_Parks", new { id = Id });
            }
            return View(blog_Content);
        }
    }
}
