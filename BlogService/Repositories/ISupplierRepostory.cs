using BlogService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Repositories
{
    public interface ISupplierRepostory
    {
        IEnumerable<SupplierDto> GetSuppliers();
        SupplierDto GetSupplierByID(int customerId);
        void InsertSupplier(SupplierDto entity);
        void DeleteSupplier(int entityId);
        void UpdateSupplier(SupplierDto entity);
        void Save();
    }
}
