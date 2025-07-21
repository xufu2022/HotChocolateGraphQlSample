using PlayList.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<Cat>()
    .AddType<Dog>()
    .AddType<Parrot>()
    .ModifyOptions(i=>i.StripLeadingIFromInterface=true);
   // .ModifyPagingOptions(o => o.RequirePagingBoundaries = false);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGraphQL();

app.RunWithGraphQLCommands(args);

app.Run();
