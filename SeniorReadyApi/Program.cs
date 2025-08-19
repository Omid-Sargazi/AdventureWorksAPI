using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



Log.Logger = new LoggerConfiguration()
.MinimumLevel.Information()
.WriteTo.Console().CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information)
);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/api/products/navie", async (AppDbContext db) =>
{
    var sw = Stopwatch.StartNew();

    var products = await db.Products
    .OrderBy(p => p.ProductID)
    .Take(1000).ToListAsync();


    var result = new List<object>();
    foreach (var p in products)
    {
        var sub = await db.ProductSubcategories
        .FirstOrDefaultAsync(s => s.ProductSubcategoryID == p.ProductSubcategoryID);

        ProductCategory? cat = null;

        if (sub != null)
        {
            cat = await db.ProductCategories
            .FirstOrDefaultAsync(c => c.ProductCategoryID == sub.ProductCategoryID);
        }

        result.Add(new
        {
            p.ProductID,
            p.Name,
            p.ProductNumber,
            Subcategory = sub?.Name,
            Category = cat?.Name
        });
    }

    sw.Stop();

    return Results.Ok(new
    {
        ms = sw.ElapsedMilliseconds,
        count = result.Count,
        data = result
    });

});


app.MapGet("/api/products/optimized", async (AppDbContext db) =>
{
    var sw = Stopwatch.StartNew();

    var query = db.Products.AsNoTracking()
    .OrderBy(p => p.ProductID)
    .Take(1000)
    .Include(p => p.ProductSubcategory)
    .ThenInclude(s => s!.ProductCategory);

    var data = await query.Select(p => new
    {
        p.ProductID,
        p.Name,
        p.ProductNumber,
        Subcategory = p.ProductSubcategory != null ? p.ProductSubcategory.Name : null,
        Category = p.ProductSubcategory != null ? p.ProductSubcategory.ProductCategory!.Name : null
    }).ToListAsync();

    sw.Stop();
    return Results.Ok(new
    {
        ms = sw.ElapsedMilliseconds,
        count = data.Count,
        data
    });
            
});

app.Run();


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> o) : base(o) { }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    public DbSet<ProductSubcategory> ProductSubcategories => Set<ProductSubcategory>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Product>().ToTable("Product", "Production").HasKey(p => p.ProductID);
        mb.Entity<ProductSubcategory>().ToTable("ProductSubcategory", "Production").HasKey(s => s.ProductSubcategoryID);
        mb.Entity<ProductCategory>().ToTable("ProductCategory", "Production").HasKey(c => c.ProductCategoryID);

        mb.Entity<Product>().HasOne(p => p.ProductSubcategory)
        .WithMany(s => s.Products)
        .HasForeignKey(p => p.ProductSubcategoryID);
    }
}












public class Product
{
    public int ProductID { get; set; }
    public string? Name { get; set; }
    public string? ProductNumber { get; set; }
    public int? ProductSubcategoryID { get; set; }
    public ProductSubcategory? ProductSubcategory { get; set; }
}

public class ProductSubcategory
{
    public int ProductSubcategoryID { get; set; }
    public string? Name { get; set; }
    public int ProductCategoryID { get; set; }
    public ProductCategory? ProductCategory { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class ProductCategory
{
    public int ProductCategoryID { get; set; }
    public string? Name { get; set; }
    public ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
}

