using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsives.Base
{
    public class BaseReponsitory<TEntity> : IBaseReponsitory<TEntity> where TEntity : class
    {
        protected IDbContext _Idbcontext;
        protected DbSet<TEntity> _Dbset;
        protected DbContext _DbContext;

        public BaseReponsitory(IDbContext dbcontext)
        {
            _Idbcontext = dbcontext;
            _DbContext = (DbContext)dbcontext;
        }
        #region Public/Protected Properties
        protected DbSet<TEntity> DBSet
        {
            get
            {
                if (_Dbset == null)
                {
                    _Dbset = _DbContext.Set<TEntity>() as DbSet<TEntity>;
                }
                return _Dbset;
            }
        }
        #endregion
        #region Public Methods
        #region Execute Stored
        public Task<List<TEntity>> ExecuteStoredProcedureAsync(string spName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteStoredProcedureNoReturnAsync(string spName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> ExecuteStoredProcedureWithSqlParamListAsync(string spName, List<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }
        #endregion Execute Store
        #region GetAll
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = predicate != null ? DBSet.Where(predicate) : DBSet;
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(List<string> includes, Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = BuildQueryable(includes, predicate);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string include, Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query;
            if (!string.IsNullOrWhiteSpace(include))
            {
                query = BuildQueryable(new List<string> { include }, predicate);
                return await query.ToListAsync();
            }
            else
                return await GetAllAsync(predicate);
        }
        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate != null ? DBSet.Where(predicate) : DBSet.AsQueryable();
        }
        #endregion GetAll
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> prodecate = null)
        {
            return await DBSet.FirstOrDefaultAsync(prodecate);
        }
        #region Get By ID
        public async Task<TEntity> GetByIDAsync(string ID)
        {
            return await DBSet.FindAsync(ID);
        }

        public async Task<TEntity> GetByIDAsync(int ID)
        {
            return await DBSet.FindAsync(ID);
        }
        public async Task<TEntity> GetByIDAsync(long ID)
        {
            return await DBSet.FindAsync(ID);
        }

        public async Task<TEntity> GetByIDAsync(short ID)
        {
            return await DBSet.FindAsync(ID);
        }

        public async Task<TEntity> GetByIDAsync(byte ID)
        {
            return await DBSet.FindAsync(ID);
        }

        public async Task<TEntity> GetByIDAsync(List<string> includes, Expression<Func<TEntity, bool>> prodecate = null)
        {
            IQueryable<TEntity> query = BuildQueryable(includes, prodecate);
            return await query.FirstOrDefaultAsync();
        }
        #endregion Get By ID

        public Task<IQueryable<TEntity>> SqlQueryAsync(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        #region Update
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
            await _Idbcontext.CommitChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(string ID, TEntity entity)
        {
            var Data = await DBSet.FindAsync(ID);
            if (Data != null)
            {
                _DbContext.Entry(entity).State = EntityState.Modified;
                await _Idbcontext.CommitChangesAsync();
            }
            return entity;
        }

        public async Task<TEntity> UpdateAsync(int ID, TEntity entity)
        {
            var Data = await DBSet.FindAsync(ID);
            if (Data != null)
            {
                _DbContext.Entry(entity).State = EntityState.Modified;
                await _Idbcontext.CommitChangesAsync();
            }
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, params object[] KeyValues)
        {
            var Data = await DBSet.FindAsync(KeyValues);
            if (Data != null)
            {
                _DbContext.Entry(entity).State = EntityState.Modified;
                await _Idbcontext.CommitChangesAsync();
            }
            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _DbContext.Entry(entity).State = EntityState.Modified;
            }
            await _Idbcontext.CommitChangesAsync();
            return entities;
        }
        #endregion Update
        #region Count
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> prodecate = null)
        {
            IQueryable<TEntity> query = prodecate != null ? DBSet.Where(prodecate) : DBSet;
            return await query.CountAsync();
        }

        public async Task<int> CountAsync(string include, Expression<Func<TEntity, bool>> prodecate = null)
        {
            IQueryable<TEntity> query = BuildQueryable(new List<string> { include }, prodecate);
            return await query.CountAsync();
        }

        public async Task<int> CountAsync(List<string> includes, Expression<Func<TEntity, bool>> prodecate = null)
        {
            IQueryable<TEntity> query = BuildQueryable(includes, prodecate);
            return await query.CountAsync();
        }

        #endregion Count
        #region Create
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            DBSet.Add(entity);
            await _Idbcontext.CommitChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities)
        {
            DBSet.AddRange(entities);
            await _Idbcontext.CommitChangesAsync();
            return entities;
        }
        #endregion Create
        #region Delete
        public async Task<bool> DeleteAsync(string ID)
        {
            var dataEntity = await DBSet.FindAsync(ID);
            if (dataEntity != null)
            {
                DBSet.Remove(dataEntity);
                await _Idbcontext.CommitChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> prodecate = null)
        {
            var dataEntity = prodecate != null ? DBSet.Where(prodecate) : null;
            if (dataEntity != null)
            {
                DBSet.RemoveRange(dataEntity);
                await _Idbcontext.CommitChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<bool> DeleteAsync(long ID)
        {
            var dataEntity = await DBSet.FindAsync(ID);
            if (dataEntity != null)
            {
                DBSet.Remove(dataEntity);
                await _Idbcontext.CommitChangesAsync();
                return true;
            }
            else return false;
        }
        #endregion Delete
        #endregion Public Methods
        protected IQueryable<TEntity> BuildQueryable(List<string> includes, Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = DBSet.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            if (includes != null && includes.Count > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public void ClearTrackedChanges()
        {
            var changedEntriesCopy = _DbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();
            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
