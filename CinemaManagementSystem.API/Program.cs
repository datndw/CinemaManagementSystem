using CinemaManagementSystem.API.Middleware;
using CinemaManagementSystem.Application.Common;
using CinemaManagementSystem.Identity.Common;
using CinemaManagementSystem.Infrastructure.Common;
using CinemaManagementSystem.Persistence.Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
AddSwaggerDoc(builder.Services);

void AddSwaggerDoc(IServiceCollection services)
{
    services.AddSwaggerGen(s =>
    {
        s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "Cinema Management System Web API using JWT Authorization with Bearer scheme. \r\n\r\n" +
            "Enter 'Bearer[space]' *Note that [space] is a space character and then your token in the token input below.\r\n\r\n" +
            "Example: 'Bearer ABC123'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        s.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });

        s.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Cinema Management Api System"
        });
    });
}

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("User", policyConfig =>
    {
        policyConfig.RequireClaim("Role", "User");
    });

    config.AddPolicy("Publisher", policyConfig =>
    {
        policyConfig.RequireClaim("Role", "Publisher");
    });

    config.AddPolicy("Administrator", policyConfig =>
    {
        policyConfig.RequireClaim("Role", "Administrator");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsPolicy",
    builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
