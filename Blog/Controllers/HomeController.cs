using BlogService.Dto;
using BlogService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public IActionResult Edit([FromServices] IPostRepository postRepository, [FromServices] IManufactureRepository manufactureRepository, [FromServices] ISupplierRepostory supplierRepostory, [FromServices] ICategoryRepository categoryRepository, int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Post = postRepository.GetPostByID(id); ;
            mymodel.Categories = categoryRepository.GetCategories();
            mymodel.Suppliers = supplierRepostory.GetSuppliers();
            mymodel.Manufactures = manufactureRepository.GetManufactures();

            return View(mymodel);
        }

        [Route("/create")]
        public IActionResult Create([FromServices] IPostRepository postRepository, [FromServices] IManufactureRepository manufactureRepository, [FromServices] ISupplierRepostory supplierRepostory, [FromServices] ICategoryRepository categoryRepository, int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Categories = categoryRepository.GetCategories();
            mymodel.Suppliers = supplierRepostory.GetSuppliers();
            mymodel.Manufactures = manufactureRepository.GetManufactures();
            return View(mymodel);
        }
    }
}
