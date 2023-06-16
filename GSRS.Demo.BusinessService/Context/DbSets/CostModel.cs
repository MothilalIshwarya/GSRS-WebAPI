using GSRS.Demo.BusinessService.Model;
using GSRS.Service.Context;
using Microsoft.EntityFrameworkCore;

namespace GSRS.Demo.BusinessService.Context
{
    public partial class Context : BaseContext, IContext
    {
        public DbSet<CostModel> CostModels { get; set; }
    }
}