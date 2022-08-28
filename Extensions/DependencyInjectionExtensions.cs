using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using FunctionalBank.WebApi.Features.User.Helpers;
using FunctionalBank.WebApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FunctionalBank.WebApi.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services) =>
        services.AddSwaggerGen(options =>
        {
            var projectDirectory = AppContext.BaseDirectory;
            
            var projectName = Assembly.GetExecutingAssembly().GetName().Name;
            var xmlFileName = $"{projectName}.xml";
            
            options.IncludeXmlComments(Path.Combine(projectDirectory, xmlFileName));
            
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Put Your access token here (drop **Bearer** prefix):",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });
            
            options.OperationFilter<OpenApiAuthFilter>();
        });

    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddScoped<JwtTokenHelper>()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = configuration.GetAuthSecret(),

                    ValidateAudience = false,
                    ValidateIssuer = false,

                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
                options.RequireHttpsMetadata = false;

                var tokenHandler = options.SecurityTokenValidators.OfType<JwtSecurityTokenHandler>().Single();
                tokenHandler.InboundClaimTypeMap.Clear();
                tokenHandler.OutboundClaimTypeMap.Clear();
            });

        return services;
    }
    
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<DatabaseContext>(options =>
        {
            var connectionString = configuration.GetPosgreSqlConnectionString();
            options.UseNpgsql(connectionString);
        });
}