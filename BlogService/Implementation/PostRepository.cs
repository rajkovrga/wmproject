using BlogModels.Models;
using BlogService.Dto;
using BlogService.Exceptions;
using BlogService.Validations;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using BlogService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogService.Implementation
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        private PostValidation _postValidation;
        public PostRepository(DataContext context, PostValidation postValidation)
        {
            _context = context;
            _postValidation = postValidation;
        }
        public void DeletePost(int entityId)
        {
            var entity = _context.Posts.Where(x => x.Id == entityId).FirstOrDefault();

            if (entity == null)
            {
                throw new ModelNotFoundException();
            }

            _context.Remove(entity);
        }
        public PostDto GetPostByID(int entityId)
        {
            var entity = _context.Posts.Include(x => x.Category).Include(x => x.Manufacture).Include(x => x.Supplier).Where(x => x.Id == entityId).FirstOrDefault();

            if (entity == null)
            {
                throw new ModelNotFoundException();
            }

            return new PostDto
            {
                Id = entity.Id,
                Category = entity.Category,
                Description = entity.Description,
                Manufacture = entity.Manufacture,
                Price = entity.Price,
                Supplier = entity.Supplier,
                Title = entity.Title
            };
        }
        public ResultPaginationDto<PostDto> GetPosts(PaginationDto search)
        {
            var items = _context.Posts.AsQueryable();
            var countItems = items.Count();
            items = items.Skip(search.PerPage * (search.CurrentPage - 1)).Take(search.PerPage);

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
            newPost.CategoryId = entity.Category.Id;
            newPost.ManufactureId = entity.Manufacture.Id;
            newPost.SupplierId = entity.Supplier.Id;
            newPost.Price = entity.Price;

            _context.Posts.Add(newPost);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdatePost(PostDto entity)
        {
            _postValidation.ValidateAndThrow(entity);

            var row = _context.Posts.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (row == null)
            {
                throw new ModelNotFoundException();
            }

            row.Title = entity.Title;
            row.Description = entity.Description;
            row.CategoryId = entity.Category.Id;
            row.ManufactureId = entity.Manufacture.Id;
            row.SupplierId = entity.Supplier.Id;
            row.Price = entity.Price;

        }
    }
}
