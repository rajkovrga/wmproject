using BlogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetCategories();
        CategoryDto GetCategoryByID(int customerId);
        void InsertCategory(CategoryDto entity);
        void DeleteCategory(int entityId);
        void UpdateCategory(CategoryDto entity);
        void Save();
    }
}
