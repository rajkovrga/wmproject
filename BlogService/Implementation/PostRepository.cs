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
        private PostUpdateValidation _postUpdateValidation;
        public PostRepository(DataContext context, PostValidation postValidation, PostUpdateValidation postUpdateValidation)
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

            _context.Remove(entity);
        }

        public int getByTitle(string title)
        {
            var r = _context.Posts.Where(x => x.Title == title).FirstOrDefault();

            if(r == null)
            {
                throw new ModelNotFoundException();
            }

            return r.Id;
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
            newPost.CategoryId = entity.CategoryId;
            newPost.ManufactureId = entity.ManufactureId;
            newPost.SupplierId = entity.SupplierId;
            newPost.Price = entity.Price;

            _context.Posts.Add(newPost);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdatePost(PostDto entity)
        {
            var r = entity;

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
