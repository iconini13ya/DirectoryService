using Microsoft.OpenApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args); // Add services to the container.

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


DirectoryService.Infrastructure.Postgres.DependencyInjection.AddInfrassttructurePostgres(builder.Services, builder.Configuration);

DirectoryService.Application.DependencyInjection.AddApplication(builder.Services);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact"),
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license"),
        },
    });
});

var app = builder.Build();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
