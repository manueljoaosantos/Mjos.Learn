using Mjos.Learn.ProductCatalog;
using Mjos.Learn.ProductCatalog.Data;
using Mjos.Learn.ProductCatalog.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddCustomCors()
    .AddEndpointsApiExplorer()
    .AddHttpContextAccessor()
    .AddCustomMediatR(new[] { typeof(Product) })
    .AddCustomValidators(new[] { typeof(Product) })
    .AddPersistence("northwind_db", builder.Configuration)
    .AddSwaggerGen()
    .AddSchemeRegistry(builder.Configuration)
    .AddCdCConsumers()
    .AddCustomDaprClient()
    .AddHealthChecks()
    .AddDbContextCheck<MainDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await WithSeriLog(async () =>
{
    await app.DoDbMigrationAsync(app.Logger);
    await app.DoSeedData(app.Logger);

    app.Run();
});
