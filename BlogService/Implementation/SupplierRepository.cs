using BlogService.Dto;
using BlogService.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Implementation
{
    public class SupplierRepository : ISupplierRepostory
    {
        private readonly DataContext _context;

        public SupplierRepository(DataContext context)
        {
            _context = context;
        }

        public void DeletePost(int entityId)
        {
            throw new NotImplementedException();
        }

        public SupplierDto GetPostByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierDto> GetPosts()
        {
            throw new NotImplementedException();
        }

        public void InsertPost(SupplierDto entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(SupplierDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
