﻿using System.Linq.Expressions;

namespace SwashbucklerDiary.IServices
{
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        Task<bool> AddAsync(TEntity entity);
        Task<int> AddReturnIdAsync(TEntity entity);
        Task<bool> AddAsync(List<TEntity> entities);
        Task<TEntity> AddReturnEntityAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> func);
        Task<bool> UpdateAsync(TEntity entity);
        Task<List<TEntity>> QueryAsync();
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);
        Task<List<TEntity>> QueryTakeAsync(int count);
        Task<TEntity> FindAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> func);
    }
}
