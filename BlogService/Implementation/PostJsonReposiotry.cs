using BlogModels.Models;
using BlogService.Dto;
using BlogService.Exceptions;
using BlogService.Repositories;
using BlogService.Validations;
using DataAccess;
using FluentValidation;
using Grpc.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BlogService.Implementation
{
    public class PostJsonReposiotry : IPostRepository
    {
        private PostJsonValidation _postValidation;
        private PostJsonUpdateValidation _postUpdateValidation;
        private readonly JsonContext _context;
        public PostJsonReposiotry(JsonContext context, PostJsonValidation postValidation, PostJsonUpdateValidation postUpdateValidation)
        {
            _context = context;
            _postValidation = postValidation;
            _postUpdateValidation = postUpdateValidation;
        }

        public void DeletePost(int entityId)
        {
            var entity = _context.Posts.Where(x => x.Id == entityId).FirstOrDefault();

            if (entity == null)
            {
                throw new ModelNotFoundException();
            }

            _context.Posts.Remove(entity);
        }


        public int getByTitle(string title)
        {
            var r = _context.Posts.Where(x => x.Title == title).FirstOrDefault();

            if (r == null)
            {
                throw new ModelNotFoundException();
            }

            return r.Id;
        }

        public PostDto GetPostByID(int entityId)
        {
            var entity = _context.Posts.Where(x => x.Id == entityId).FirstOrDefault();

            if (entity == null)
            {
                throw new ModelNotFoundException();
            }



            return new PostDto
            {
                Id = entity.Id,
                Category = _context.Categories.Where(x => x.Id == entity.CategoryId).First(),
                Description = entity.Description,
                Manufacture = _context.Manufactures.Where(x => x.Id == entity.ManufactureId).First(),
                Price = entity.Price,
                Supplier = _context.Suppliers.Where(x => x.Id == entity.SupplierId).First(),
                Title = entity.Title
            };
        }

        public ResultPaginationDto<PostDto> GetPosts(PaginationDto search)
        {
            var items = _context.Posts.ToList();
            var countItems = items.Count();
            items = items.Skip(search.PerPage * (search.CurrentPage - 1)).Take(search.PerPage).ToList();

            return new ResultPaginationDto<PostDto>
            {
                Items = items.Select(x => new PostDto
                {
                    Id = x.Id,
                    Category = x.Category,
                    Description = x.Description,
                    Manufacture = x.Manufacture,
                    Price = x.Price,
                    Supplier = x.Supplier,
                    Title = x.Title
                }).ToList(),
                CountItems = countItems,
                CurrentPage = search.CurrentPage,
                PerPage = search.PerPage
            };
        }

        public void InsertPost(PostDto entity)
        {
            _postValidation.ValidateAndThrow(entity);

            var newPost = new Post();

            newPost.Title = entity.Title;
            newPost.Description = entity.Description;
            newPost.CategoryId = entity.CategoryId;
            newPost.ManufactureId = entity.ManufactureId;
            newPost.SupplierId = entity.SupplierId;
            newPost.Price = entity.Price;

            _context.Posts.Add(newPost);
           
        }
        public void Save()
        {

        }

        public void UpdatePost(PostDto entity)
        {
            _postUpdateValidation.ValidateAndThrow(entity);

            var row = _context.Posts.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (row == null)
            {
                throw new ModelNotFoundException();
            }

            row.Title = entity.Title;
            row.Description = entity.Description;
            row.CategoryId = entity.CategoryId;
            row.ManufactureId = entity.ManufactureId;
            row.SupplierId = entity.SupplierId;
            row.Price = entity.Price;

        }
    }
}
