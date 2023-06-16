using GSRS.Service.ModelContracts;
using GSRS.Service.Models;

namespace GSRS.Service.RepositoryContracts
{
    public interface IBaseRepositoryAsync<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Repository scaffold to create a new BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task<int> CreateAsync(TEntity entity);
        // Task<bool> CreatListeAsync(List<TEntity> entity);
        /// <summary>
        /// Repository scaffold to hard delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Repository scaffold to soft delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task SoftDeleteAsync(TEntity entity);

        /// <summary>
        /// Repository scaffold to update a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Repository scaffold to search a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task<Dictionary<int, TEntity>> SearchUnrestrictedAsync(ISearchCondition<TEntity> searchCondition);

        /// <summary>
        /// Repository scaffold to fetch a BaseModel entity by id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        Task<TEntity> FetchAsync(int id, bool isTracked = true);
    }
}
