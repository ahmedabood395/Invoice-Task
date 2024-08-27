using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Repository.Interfaces
{
  public  interface IRepository<T>
    {
        T GetById(Guid id);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null ,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy =null,
           string includeProperties="");
        IQueryable<T> GetAll();

        void Update(T entity);

        void Insert(T entity);

        void Delete(T entity);
        void AddRange(IEnumerable<T> entities);

        void DeleteRange(IEnumerable<T> entities);
        Task DeleteAysnc(T entity);
         Task<List<T>> GetAllAsync();
         Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAsync(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = "");

        public IQueryable<T> GetAllByRange(int page, int pageSize);

    }
}
