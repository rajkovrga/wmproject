using BlogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Repositories
{
    public interface IManufactureRepository
    {
        IEnumerable<ManufactureDto> GetManufactures();
        ManufactureDto GetManufactureByID(int customerId);
        void InsertManufacture(ManufactureDto entity);
        void DeleteManufacture(int entityId);
        void UpdateManufacture(ManufactureDto entity);
        void Save();
    }
}
