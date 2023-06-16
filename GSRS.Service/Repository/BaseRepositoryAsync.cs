using System.Collections;
using System.Reflection;
// using GSRS.Diagnostics.Exceptions;
using GSRS.Service.ContextContracts;
using GSRS.Service.ModelContracts;
using GSRS.Service.Models;
using GSRS.Service.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Service.Repository
{
    public abstract class BaseRepositoryAsync<TEntity> : IBaseRepositoryAsync<TEntity> where TEntity : BaseModel
    {
        public readonly IBaseContext Context;
        protected BaseRepositoryAsync(IBaseContext _context)
        {
            Context = _context;

        }
        protected virtual DbSet<TEntity> DbSet
        {
            get { return Context.SetEntity<TEntity>(); }
        }
        protected virtual IQueryable<TEntity> Query
        {

            get { return Context.SetQuery<TEntity>(); }
        }
        /// <summary>
        /// Repository scaffold to create a new BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            // Add the transient object to context
            DbSet.Add(entity);
            // Commit context changes
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// Repository scaffold to update a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            // Fetch the existing entity
            var existingEntity = Query.FirstOrDefault(c => c.Id.Equals(entity.Id));
            if (existingEntity != null)            {
                // Update modified values
                 CopyPropertiesTo(entity, existingEntity);
                // Attach changes to context
                Context.SetModified(existingEntity);
                // Commit context changes
                await Context.SaveChangesAsync();
            }
            return existingEntity.Id;
        }

        /// <summary>
        /// Repository scaffold to hard delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            // Fetch the existing entity
            var deletedTEntity = Query.FirstOrDefault(x => x.Id == entity.Id);
            if (deletedTEntity != null)
            {
                // Mark entity as deleted
                Context.SetDeleted(deletedTEntity);
                // Commit context changes
                await Context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Repository scaffold to soft delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task SoftDeleteAsync(TEntity entity)
        {
            // Fetch the existing entity
            var deletedTEntity = Query.FirstOrDefault(x => x.Id == entity.Id);
            if (deletedTEntity != null)
            {
               
                // Mark entity as modified
                Context.SetModified(deletedTEntity);
                // Commit context changes
                await Context.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Repository scaffold to fetch BaseModel entity by a search condition predicate
        /// This fetch is Tenant agnostic.
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual Task<Dictionary<int, TEntity>> SearchUnrestrictedAsync(ISearchCondition<TEntity> searchCondition)
        {
            // Get base tenant agnostic query
            var entities = Query.AsNoTracking();

            if (searchCondition != null)
            {
                // Include search condition predicate
                entities = Query.Where(searchCondition.Predicate);
            }
            // Execute query and convert results to a dictionary 
            var result = entities.ToDictionary(x => x.Id, x => x);

            return Task.FromResult(result);
        }

        /// <summary>
        /// Repository scaffold to fetch BaseModel entity by Id (int) with EF tracking settings
        /// This fetch is restricted by Tenant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual Task<TEntity> FetchAsync(int id, bool isTracked = true)
        {
            // For already existing entity validations
            if (!isTracked)
            {
                // Get the untracked entity from context
                var result = Query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            // Fetch the existing entity by Id
            return FetchEntityByIdAsync(id);
        }


        #region Private methods

        /// <summary>
        /// Fetch existing entity with change tracking
        /// This action is restricted by tenant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Task<TEntity> FetchEntityByIdAsync(int id)
        {
            // Query includes tenant check
            var result = Query.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

       

        private void CopyPropertiesTo(object modifiedEntity, object entityFromDb)
        {
           
            // Get destination object type(int/string)
            var typeDest = entityFromDb.GetType();

            // Iterate the Properties(name,description) of the source instance and  
            //  populate them from their desination counterparts
            foreach (var srcProp in typeDest.GetProperties())
            {
                
                var targetProperty = typeDest.GetProperty(srcProp.Name);
                
                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                
                 if(targetProperty.Name.ToLower()=="datecreated"){
                    var sourceValue1 = srcProp.GetValue(entityFromDb, null);
                    targetProperty.SetValue(entityFromDb,sourceValue1,null);
                 }
                 else{
                    var sourceValue = srcProp.GetValue(modifiedEntity, null);
                    targetProperty.SetValue(entityFromDb, sourceValue, null);
                 }
                   
            }
        }
        #endregion Private methods
    }
}
