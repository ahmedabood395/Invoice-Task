using Microsoft.EntityFrameworkCore;
using OrobaSoft.Repository.Context;
using OrobaSoft.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Repository
{
   public class GenericRepository<T> : IRepository<T> where T:class
    {
        InvoiceContext _dbContext;
        public DbSet<T> dbset;

        public InvoiceContext DbContext { get => _dbContext; set => _dbContext = value; }
        public GenericRepository(InvoiceContext context )
        {
          
           _dbContext = context;
           dbset=  _dbContext.Set<T>();
        }
        public void Delete(T entity)
        { try
            {
               
                _dbContext.Entry(entity).State = EntityState.Deleted;
                dbset.Remove(entity);
            }
            catch (Exception )
            {
              
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return dbset;
            }
            catch (Exception )
            {
                return null;
            }
        }


        public T GetById(Guid id)
        {
            try
            {
                return dbset.Find(id);
            }
            catch (Exception )
            {
                return null;
            }
        }

        public virtual IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            try {
                _dbContext.Set<T>().Local.ToList().ForEach(x =>
                {
                    _dbContext.Entry(x).State = EntityState.Detached;

                });
                IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter );
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }
            catch (Exception ex)
            {
                return null;
            }
        }


        public void Insert(T entity)
        {
            try { 
            dbset.Add(entity);
        }
            catch (Exception )
            {
                
            }
        }

        public void Update(T entity)
        {
            try
            {
               
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception )
            {
                
            }
            
        }
        public void AddRange(IEnumerable<T> entities)
        {
            try { 
            dbset.AddRange(entities);
        }
            catch (Exception )
            {
               
            }
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            try { 
            _dbContext.RemoveRange(entities);
        }
            catch (Exception )
            {
               
            }
        }
        public async Task DeleteAysnc(T entity)
        {
            try
            {

               _dbContext.Entry(entity).State = EntityState.Deleted;
               dbset.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception )
            {
            }
        }
        public virtual async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await dbset.ToListAsync();
            }
            catch (Exception )
            {
                return null;
            }
        }
        public virtual async Task UpdateAsync(T entity)
        {
            try
            {

                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception )
            {

            }

        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await dbset.FindAsync(id);
            }
            catch (Exception )
            {
                return null;
            }
        }

        public virtual async Task<List<T>> GetAsync(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "")
        {
            try
            {
                _dbContext.Set<T>().Local.ToList().ForEach(x =>
                {
                    _dbContext.Entry(x).State = EntityState.Detached;

                });

                IQueryable<T> query = dbset;
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public virtual async Task InsertAsync(T entity)
        {
            try
            {
                dbset.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception )
            {

            }
        }
        public IQueryable<T> GetAllByRange(int page, int pageSize)
        {
            try
            {
                return dbset.Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception )
            {
                return null;
            }
        }

    }
}
