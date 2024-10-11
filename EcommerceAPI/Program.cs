using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ecommerce;
using Ecommerce.Helpers;
using Ecommerce.MongoSettings;
using Ecommerce.Repositories;
using Ecommerce.Services;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
    options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
}).AddNewtonsoftJson(json => json.UseMemberCasing());

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDContext<>));

// services
builder.Services.AddTransient(typeof(IProductService), typeof(ProductService));

// repositories
builder.Services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));

builder.Services.Configure<MongoDbSettings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("MongoDbConnection:ConnectionString").Value;
    options.Database = builder.Configuration.GetSection("MongoDbConnection:Database").Value;
});

// Get app configurations
AppConfig appConfig = configuration.GetSection("AppConfig").Get<AppConfig>();
builder.Services.AddSingleton(appConfig);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
