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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void DeleteCategory(int entityId)
        {
            var item = _context.Categories.Find(entityId);

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            _context.Remove(item);
        }

        public CategoryDto GetCategoryByID(int customerId)
        {
            var item = _context.Categories.Find(customerId);

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            return new CategoryDto { 
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

            _context.Add(newItem);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCategory(CategoryDto entity)
        {
            var item = _context.Categories.Find(entity.Id);

            if(item == null)
            {
                throw new ModelNotFoundException();
            }

            item.Name = entity.Name;
            
        }
    }
}
