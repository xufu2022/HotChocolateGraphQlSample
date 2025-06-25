using Samples.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton<PetRepository>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddObjectType<Dog>()
    .AddObjectType<Cat>()
    .AddObjectType<Parrot>()
    .ModifyOptions(options => options.EnableOneOf = true)
    .ModifyPagingOptions(o => o.RequirePagingBoundaries = false);

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
app.MapGraphQL();

app.RunWithGraphQLCommands(args);

app.UseAuthorization();

app.MapControllers();

app.Run();
