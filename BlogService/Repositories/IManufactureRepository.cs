using BlogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Repositories
{
    public interface IManufactureRepository
    {
        IEnumerable<ManufactureDto> GetPosts();
        ManufactureDto GetPostByID(int customerId);
        void InsertPost(ManufactureDto entity);
        void DeletePost(int entityrId);
        void UpdatePost(ManufactureDto entity);
        void Save();
    }
}
