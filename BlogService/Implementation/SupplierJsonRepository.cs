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
    public class SupplierJsonRepository : ISupplierRepostory
    {
        private readonly JsonContext _context;

        public SupplierJsonRepository(JsonContext context)
        {
            _context = context;
        }

        public void DeleteSupplier(int entityId)
        {
            var item = _context.Suppliers.Where(x => x.Id == entityId).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            _context.Suppliers.Remove(item);

        }

        public SupplierDto GetSupplierByID(int customerId)
        {
            var item = _context.Suppliers.Where(x => x.Id == customerId).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            return new SupplierDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public IEnumerable<SupplierDto> GetSuppliers()
        {
            var items = _context.Suppliers.ToList();

            return items.Select(x => new SupplierDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public void InsertSupplier(SupplierDto entity)
        {
            var newItem = new Supplier();

            newItem.Name = entity.Name;

            _context.Suppliers.Add(newItem);
        }

        public void Save()
        {
        }

        public void UpdateSupplier(SupplierDto entity)
        {
            var item = _context.Suppliers.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            item.Name = entity.Name;
        }
    }
}
