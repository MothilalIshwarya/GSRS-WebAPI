using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace GSRS.Infrastructure.Helpers
{
    public static class ContextHelper
    {
        public static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            // This object contains information about the SQL Server connection string and other SQL Server-specific options.
            var sqlExt = options.Extensions.FirstOrDefault(e => e is SqlServerOptionsExtension);

            if (sqlExt == null)
                throw (new Exception("Failed to retrieve SQL connection string for base Context"));

            return new DbContextOptionsBuilder<T>()
                     .UseSqlServer(((SqlServerOptionsExtension)sqlExt).ConnectionString)
                     .Options;
        }
    }
}
