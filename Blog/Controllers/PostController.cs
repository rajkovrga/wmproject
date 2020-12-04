using BlogService.Dto;
using BlogService.Exceptions;
using BlogService.Repositories;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        [HttpPost]
        [Route("/create")]
        public IActionResult Create([FromServices] IPostRepository postRepository)
        {
            try
            {
                var r = Request.Form;
                postRepository.InsertPost(new PostDto
                {
                    Title = r["title"].ToString(),
                    CategoryId = Convert.ToInt32(r["category"]),
                    ManufactureId = Convert.ToInt32(r["manufacture"]),
                    SupplierId = Convert.ToInt32(r["supplier"]),
                    Description = r["description"].ToString(),
                    Price = Convert.ToDecimal((String.IsNullOrEmpty(r["price"]) ? 0 : Convert.ToDecimal(r["price"])))
                });

                postRepository.Save();
                return Redirect("/posts/" + postRepository.getByTitle(r["title"]));
            }
            catch(FluentValidation.ValidationException er)
            {
                TempData["error"] = er.Message;
                return RedirectToAction("Create");
            }
            catch (Exception)
            {
                TempData["error"] = "Server error";
                return RedirectToAction("Create");

            }
        }


        [HttpPost]
        [Route("/edit/{id}")]
        public IActionResult Edit(int id, [FromServices] IPostRepository postRepository)
        {
            try
            {
                var r = Request.Form;
                postRepository.UpdatePost(new PostDto
                {
                    Id = id,
                    Title = r["title"],
                    CategoryId = Convert.ToInt32(r["category"]),
                    ManufactureId = Convert.ToInt32(r["manufacture"]),
                    SupplierId = Convert.ToInt32(r["supplier"]),
                    Description = r["description"],
                    Price = Convert.ToDecimal(r["price"])
                });

                postRepository.Save();

                return Redirect("/posts/" + id);
            }
            catch (ModelNotFoundException)
            {
                TempData["error"] = "Model not found";
                return RedirectToAction("Create");
            }
            catch (FluentValidation.ValidationException er)
            {
                TempData["error"] = er.Message;
                return RedirectToAction("Create");
            }
            catch (Exception)
            {
                TempData["error"] = "Server error";
                return RedirectToAction("Create");

            }
        }

        [HttpGet]
        [Route("/delete/{id}")]
        public IActionResult Delete(int id, [FromServices] IPostRepository postRepository)
        {
            try
            {
                postRepository.DeletePost(id);
                postRepository.Save();

                TempData["result"] = "Success deleted";
                return Redirect("/result");
            }
            catch (ModelNotFoundException)
            {
                TempData["result"] = "Model not found";
                return RedirectToAction("Create");
            }
            catch (Exception)
            {
                TempData["result"] = "Server error";
                return RedirectToAction("Result");


            }
        }
    }
}
