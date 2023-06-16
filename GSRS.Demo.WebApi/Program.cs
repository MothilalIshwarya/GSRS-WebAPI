using Microsoft.EntityFrameworkCore;
using GSRS.Api.BaseMappers;
using GSRS.Demo.BusinessService.Context;
using GSRS.Demo.BusinessService.RepositoryContracts;
using GSRS.Demo.BusinessService.Repository;
using GSRS.Demo.BusinessService.ServiceContracts;
using GSRS.Demo.BusinessService.Services;
using GSRS.Api.BaseMapperContracts;
using GSRS.Api.ControllerContracts;
using GSRS.Api.Controllers;
// using GSRS.Infrastructure.QueueHelper.Contract;
// using GSRS.Infrastructure.QueueHelper;
using GSRS.Infrastructure.ErrorHandlingMiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbCOntext
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


//Register Repository
builder.Services.AddScoped<IAgreementRepository, AgreementRepository>();
builder.Services.AddScoped<IAutoImportTypeRepository, AutoImportTypeRepository>();
builder.Services.AddScoped<ICostModelRepository, CostModelRepository>();
builder.Services.AddScoped<IImportTypeRepository, ImportTypeRepository>();
builder.Services.AddScoped<ILicenseServerGroupRepository, LicenseServerGroupRepository>();
builder.Services.AddScoped<ILicenseTypeRepository, LicenseTypeRepository>();
builder.Services.AddScoped<ILicenseServerRepository, LicenseServerRepository>();
builder.Services.AddScoped<IProductGroupPriceRepository, ProductGroupPriceRepository>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitDefinitionRepository, UnitDefinitionRepository>();
builder.Services.AddScoped<IUnitFactorRepository, UnitFactorRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IModContractRepository, ModContractRepository>();

//Register Services
builder.Services.AddScoped<IAgreementService, AgreementService>();
builder.Services.AddScoped<IAutoImportTypeService, AutoImportTypeService>();
builder.Services.AddScoped<ICostModelService, CostModelService>();
builder.Services.AddScoped<IImportTypeService, ImportTypeService>();
builder.Services.AddScoped<ILicenseServerGroupService, LicenseServerGroupService>();
builder.Services.AddScoped<ILicenseTypeService, LicenseTypeService>();
builder.Services.AddScoped<ILicenseServerService, LicenseServerService>();
builder.Services.AddScoped<IProductGroupPriceService, ProductGroupPriceService>();
builder.Services.AddScoped<IProductGroupService, ProductGroupService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitDefinitionService, UnitDefinitionService>();
builder.Services.AddScoped<IUnitFactorService, UnitFactorService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IModContractService, ModContractService>();
//Register Context
builder.Services.AddScoped<IContext, Context>();

//Register Mapper
builder.Services.AddScoped(typeof(IBaseDtoToModelMapper<,>), typeof(BaseDtoToModelMapper<,>));
builder.Services.AddScoped(typeof(IBaseModelToDtoMapper<,>), typeof(BaseModelToDtoMapper<,>));

//Register Base Controller
builder.Services.AddScoped(typeof(IBaseAsyncController<,>), typeof(BaseAsyncController<,>));

//Auto Mapper       
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:4200");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
