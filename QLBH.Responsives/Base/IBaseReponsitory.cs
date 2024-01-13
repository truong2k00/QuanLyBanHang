using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsives.Base
{
    public interface IBaseReponsitory<TEntity>
    {
        #region Get
        #region All
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<TEntity>> GetAllAsync(List<string> includes, Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<TEntity>> GetAllAsync(string include, Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate = null);
        #endregion All
        #region Get By ID
        Task<TEntity> GetByIDAsync(string ID);
        Task<TEntity> GetByIDAsync(int ID);
        Task<TEntity> GetByIDAsync(short ID);
        Task<TEntity> GetByIDAsync(long ID);
        Task<TEntity> GetByIDAsync(byte ID);
        Task<TEntity> GetByIDAsync(List<string> includes,Expression<Func<TEntity, bool>> prodecate = null);
        #endregion Get By ID
        #endregion Get
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> prodecate = null);
        #region Remove
        Task<bool> DeleteAsync(string ID);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> prodecate = null);
        Task<bool> DeleteAsync(long ID);
        #endregion Remove
        #region Create
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities);
        #endregion Create
        #region Update
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(string ID, TEntity entity);
        Task<TEntity> UpdateAsync(int ID, TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, params object[] KeyValues);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        #endregion Update
        #region Count
        Task<int> CountAsync(Expression<Func<TEntity, bool>> prodecate = null);
        Task<int> CountAsync(string include, Expression<Func<TEntity, bool>> prodecate = null);
        Task<int> CountAsync(List<string> includes, Expression<Func<TEntity, bool>> prodecate = null);
        #endregion Count
        #region Execute Stored
        Task ExecuteStoredProcedureNoReturnAsync(string spName, params object[] parameters);
        Task<List<TEntity>> ExecuteStoredProcedureAsync(string spName, params object[] parameters);
        Task<List<TEntity>> ExecuteStoredProcedureWithSqlParamListAsync(string spName, List<SqlParameter> parameters);
        #endregion Execute Stored
        Task<IQueryable<TEntity>> SqlQueryAsync(string query, params object[] parameters);
        void ClearTrackedChanges();
    }
}
