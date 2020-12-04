using BlogModels.Models;
using BlogService.Dto;
using BlogService.Exceptions;
using BlogService.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogService.Implementation
{
    public class CategoryJsonRepository : ICategoryRepository
    {
        private readonly JsonContext _context;

        public CategoryJsonRepository(JsonContext context)
        {
            _context = context;
        }
        public void DeleteCategory(int entityId)
        {
            var item = _context.Categories.Where(x => x.Id == entityId).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            _context.Categories.Remove(item);

        }

        public CategoryDto GetCategoryByID(int customerId)
        {
            var item = _context.Categories.Where(x => x.Id == customerId).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            return new CategoryDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var items = _context.Categories.ToList();

            return items.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public void InsertCategory(CategoryDto entity)
        {
            var newItem = new Category();

            newItem.Name = entity.Name;

            _context.Categories.Add(newItem);
        }

        public void Save()
        {
        }

        public void UpdateCategory(CategoryDto entity)
        {
            var item = _context.Categories.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            item.Name = entity.Name;
        }
    }
}
