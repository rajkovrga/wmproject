using BlogService.Dto;
using BlogService.Exceptions;
using BlogService.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
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

        public void DeletePost(int entityId)
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetPostByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetPosts()
        {
            throw new NotImplementedException();
        }

        public void InsertPost(CategoryDto entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePost(CategoryDto entity)
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
