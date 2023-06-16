using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.Model;
using GSRS.Service.Context;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Demo.BusinessService.Context
{
    public partial class Context : BaseContext, IContext
    {
        public DbSet<LicenseType> licenseTypes { get; set; }
    }
}