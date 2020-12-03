using BlogService.Dto;
using BlogService.Repositories;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Implementation
{
    public class ManufactureRepository : IManufactureRepository
    {
        private readonly DataContext _context;

        public ManufactureRepository(DataContext context)
        {
            _context = context;
        }

        public void DeletePost(int entityId)
        {
            throw new NotImplementedException();
        }

        public ManufactureDto GetPostByID(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManufactureDto> GetPosts()
        {
            throw new NotImplementedException();
        }

        public void InsertPost(ManufactureDto entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(ManufactureDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
