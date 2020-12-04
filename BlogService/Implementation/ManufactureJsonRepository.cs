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
    public class ManufactureJsonRepository : IManufactureRepository
    {
        private readonly JsonContext _context;

        public ManufactureJsonRepository(JsonContext context)
        {
            _context = context;
        }

        public void DeleteManufacture(int entityId)
        {
            var item = _context.Manufactures.Where(x => x.Id == entityId).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            _context.Manufactures.Remove(item);

        }

        public ManufactureDto GetManufactureByID(int customerId)
        {
            var item = _context.Manufactures.Where(x => x.Id == customerId).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            return new ManufactureDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }


        public IEnumerable<ManufactureDto> GetManufactures()
        {
            var items = _context.Manufactures.ToList();

            return items.Select(x => new ManufactureDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public void InsertManufacture(ManufactureDto entity)
        {
            var newItem = new Manufacture();

            newItem.Name = entity.Name;

            _context.Manufactures.Add(newItem);
        }

        public void Save()
        {
        }

        public void UpdateManufacture(ManufactureDto entity)
        {
            var item = _context.Manufactures.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (item == null)
            {
                throw new ModelNotFoundException();
            }

            item.Name = entity.Name;
        }
    }
}
