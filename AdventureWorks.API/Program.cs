using AdventureWorks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdventureWorksDbContext>(optiins =>
    optiins.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler";
    options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
     options.TrackConnectionOpenClose = true; // رصد باز/بسته شدن اتصالات دیتابیس
    options.EnableMvcFilterProfiling = true; // رصد فیلترهای MVC
}).AddEntityFramework();

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

