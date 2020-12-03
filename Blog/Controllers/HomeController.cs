using BlogService.Dto;
using BlogService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }
        [Route("/posts")]
        [Route("/")]
        public IActionResult Index([FromServices] IPostRepository postRepository, [FromQuery] int page = 1)
        {
            var model = postRepository.GetPosts(new PaginationDto { 
                CurrentPage = page,
                PerPage = 4
            });

            return View(model);
        }
        [Route("/edit/{id}")]
        public IActionResult Edit([FromServices] IPostRepository postRepository, int id)
        {
            var model = postRepository.GetPostByID(id);

            return View(model);
        }
    }
}
