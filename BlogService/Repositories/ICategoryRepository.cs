using BlogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetPosts();
        CategoryDto GetPostByID(int customerId);
        void InsertPost(CategoryDto entity);
        void DeletePost(int entityrId);
        void UpdatePost(CategoryDto entity);
        void Save();
    }
}
