using eShop.Catalog.API.Data;
using eShop.Catalog.API.Extensions;
using eShop.Catalog.API.Migrations;
using eShop.Catalog.API.Types;
using eShop.Catalog.API.Types.Filtering;
using eShop.Catalog.API.Types.Sorting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));
builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductFilterInputType>()
    .AddType<ProductSortInputType>()
    .AddGraphQLConventions();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);
app.Run();
