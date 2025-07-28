using AdventureWorks.API.Middleware;
using AdventureWorks.Application.Features.Products.Commands.CreateProduct;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Infrastructure;
using AdventureWorks.Infrastructure.Repository.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdventureWorksDbContext>(optiins =>
    optiins.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler";
    options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
    options.TrackConnectionOpenClose = true; // رصد باز/بسته شدن اتصالات دیتابیس
    options.EnableMvcFilterProfiling = true; // رصد فیلترهای MVC
}).AddEntityFramework();

builder.Services.AddStackExchangeRedisCache(optiins =>
{
    optiins.Configuration = "localhost:6379";
    optiins.InstanceName = "AdventureWorks_";
});

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AdventureWorks API",
        Version = "v1",
        Description = "API for AdventureWorks Database"
    });
});


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdventureWorks API V1");
    });
}

app.UseMiniProfiler();

app.UseHttpsRedirection();

// اگر از کنترلر استفاده می‌کنید
app.MapControllers();

app.Run();

