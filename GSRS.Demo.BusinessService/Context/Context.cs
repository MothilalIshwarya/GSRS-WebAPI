using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GSRS.Service.Context;
using GSRS.Infrastructure.Helpers;

namespace GSRS.Demo.BusinessService.Context
{
    public partial class Context : BaseContext, IContext
    {

        public Context(DbContextOptions<Context> options) : base(ContextHelper.ChangeOptionsType<BaseContext>(options))
        {
            //This method ensures that the database for the context exists and creates it if it doesn't.
            // If the database already exists, this method does nothing.
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
            base.OnModelCreating(modelBuilder);

        }
    }
}


