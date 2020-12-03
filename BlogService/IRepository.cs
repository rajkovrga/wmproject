using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BlogService.Dto;

namespace BlogService
{
    public interface IRepository<TEntity, TResult, TSearch> where TEntity : class
    {
        TResult GetList(TSearch search);
        TEntity GetByID(int customerId);
        void Insert(TEntity entity);
        void Delete(int entityrId);
        void Update(TEntity entity);
        void Save();
    }
}
