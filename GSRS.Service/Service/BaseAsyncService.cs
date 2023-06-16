using GSRS.Service.ModelContracts;
using GSRS.Service.Models;
using GSRS.Service.RepositoryContracts;
using GSRS.Service.ServiceContracts;

namespace GSRS.Service.Services
{
    public class BaseAsyncService<TEntity> : IBaseAsyncService<TEntity> where TEntity : BaseModel
    {
        protected readonly IBaseRepositoryAsync<TEntity> Dal;
        public BaseAsyncService(IBaseRepositoryAsync<TEntity> dal)
        {
            Dal = dal;
        }
        public async virtual Task<int> CreateAsync(TEntity entity)
        {
            // Populate audit fields
            SetCreateAuditFields(entity);
            var result = await Dal.CreateAsync(entity);
            return result;
        }

        /// <summary>
        /// Service scaffold to update a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<int> UpdateAsync(TEntity entity)
        {
            // Populate audit fields
            SetUpdateAuditFields(entity);
            var result=await Dal.UpdateAsync(entity);
            return result;

        }

        /// <summary>
        /// Service scaffold to hard delete a BaseModel entity
        /// This search is restricted by Tenant i.e hard deletes entities for the tenant
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<bool> DeleteAsync(TEntity entity)
        {
            await Dal.DeleteAsync(entity);
            return true;
        }

        /// <summary>
        /// Service scaffold to soft delete a BaseModel entity
        /// This search is restricted by Tenant i.e soft deletes entities for the tenant
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<bool> SoftDeleteAsync(TEntity entity)
        {
            // Populate audit fields
            SetUpdateAuditFields(entity);
            await Dal.SoftDeleteAsync(entity);
            return true;
        }

        /// <summary>
        /// Service scaffold to get BaseModel entity by BaseModel.Id with EF tracking settings
        /// This action is restricted by Tenant i.e returns resultSet for the tenant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<TEntity> GetByIdAsync(int id, bool isTracked = true)
        {
            var entity = await Dal.FetchAsync(id, isTracked);
            return entity;
        }



        #region Search

        /// <summary>
        /// Service scaffold to search BaseModel entity using search condition predicate object
        /// This search is restricted by Tenant i.e returns resultSet for the tenant
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<Dictionary<int, TEntity>> SearchAsync(ISearchCondition<TEntity> searchCondition = null)
        {
            var entities = await Dal.SearchUnrestrictedAsync(searchCondition);

            return entities;
        }

        /// <summary>
        /// Service scaffold to search BaseModel entity using search condition predicate string
        /// This search is not restricted by Tenant i.e returns resultSet across tenants
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>ServiceException</throws>
        public async virtual Task<Dictionary<int, TEntity>> SearchUnrestrictedAsync(ISearchCondition<TEntity> searchCondition)
        {
            return await Dal.SearchUnrestrictedAsync(searchCondition);
        }

        #endregion        
        /// <summary>
        /// Populate audit fields for create action
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void SetCreateAuditFields(TEntity entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.ChangedBy = Environment.UserName;
        }

        /// <summary>
        /// Populate audit fields for update action
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void SetUpdateAuditFields(TEntity entity)
        {
            entity.DateChanged = DateTime.UtcNow;
            entity.ChangedBy = Environment.UserName;
        }
    }
}