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

app.MapGet("/api/products/search/naive1", async (
    AppDbContext db, string? term, int page = 1, int pageSize = 20
) =>
{
    var sw = Stopwatch.StartNew();

    var all = await db.Products
     .OrderBy(p => p.ProductID)
     .ToListAsync();

    if (!string.IsNullOrWhiteSpace(term))
        all = [.. all.Where(p => (p.Name ?? "").Contains(term, StringComparison.OrdinalIgnoreCase))];

    var total = all.Count;

    var items = all
          .Skip((page - 1) * pageSize)
          .Take(pageSize)
          .Select(p => new ProductListItem(
              p.ProductID, p.Name, p.ProductNumber, p.ListPrice ?? 0,
              Category: null, Subcategory: null))
          .ToList();

    sw.Stop();

    return Results.Ok(new PagedResult<ProductListItem>(
        Page: page,
        PageSize: pageSize,
        Total: total,
        TotalPage: (int)Math.Ceiling(total / (double)pageSize),
        Ms: sw.ElapsedMilliseconds,
        SqlHint: "IN-MEMORY FILTER (BAD)",
        Items: items
    ));

});


app.MapGet("/api/products/search/naive2", async (AppDbContext db, string? term, int page = 1, int pageSize = 20) =>
{
    var sw = Stopwatch.StartNew();

    var q = db.Products.AsQueryable();

    if (!string.IsNullOrWhiteSpace(term))
        q = q.Where(p => p.Name != null && EF.Functions.Like(p.Name, $"%{term}"))
    .TagWith("Like'%term%'(non-sargable)");

    var total = await q.CountAsync();

    var items = await q.AsNoTracking()
      .OrderBy(p => p.Name)
      .Skip((page - 1) * pageSize)
      .Take(pageSize)
      .Select(p => new ProductListItem(
          p.ProductID, p.Name, p.ProductNumber, p.ListPrice ?? 0,
          null,
          null))
      .ToListAsync();


    sw.Stop();
    return Results.Ok(new PagedResult<ProductListItem>(
        page, pageSize, total, (int)Math.Ceiling(total / (double)pageSize),
        sw.ElapsedMilliseconds,
        "SQL: LIKE '%term%' (likely INDEX SCAN)",
        items
    ));
});

app.MapGet("/api/products/search/optimized", async (
    AppDbContext db, string? term, int page = 1, int pageSize = 20
) =>
{
    var sw = Stopwatch.StartNew();
    var q = db.Products.AsNoTracking();

    if (!string.IsNullOrWhiteSpace(term))
        q = q.Where(p => p.Name != null && p.Name.StartsWith(term)).TagWith("SARGable: Name LIKE @term + '%'");

    var total = await q.CountAsync();

    var pageQuery = q.OrderBy(p => p.Name).ThenBy(p => p.ProductID)
    .Skip((page - 1) * pageSize).Take(pageSize)
    .Select(p => new ProductListItem(
        p.ProductID,
        p.Name,
        p.ProductNumber,
        p.ListPrice ?? 0,
        p.ProductSubcategory != null ? p.ProductSubcategory.ProductCategory!.Name : null,
        p.ProductSubcategory != null ? p.ProductSubcategory.Name : null
    ));

    var items = await pageQuery.ToListAsync();

    sw.Stop();

    return Results.Ok(new PagedResult<ProductListItem>(
        page, pageSize, total, (int)Math.Ceiling(total / (double)pageSize),
        sw.ElapsedMilliseconds,
        "SQL: LIKE 'term%' + Projection + NoTracking",
        items
    ));
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
    public decimal? ListPrice { get; set; }
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



public record ProductListItem
(
   int ProductID,
    string? Name,
    string? ProductNumber,
    decimal? ListPrice,
    string? Category,
    string? Subcategory
);

public record PagedResult<T>(
    int Page,
    int PageSize,
    int Total,
    int TotalPage,
    long Ms,
    string? SqlHint,
    IReadOnlyList<T> Items
);

