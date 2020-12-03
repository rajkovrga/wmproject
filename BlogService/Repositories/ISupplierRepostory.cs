using BlogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Repositories
{
    public interface ISupplierRepostory
    {
        IEnumerable<SupplierDto> GetPosts();
        SupplierDto GetPostByID(int customerId);
        void InsertPost(SupplierDto entity);
        void DeletePost(int entityId);
        void UpdatePost(SupplierDto entity);
        void Save();
    }
}
