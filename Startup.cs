using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using FunctionalBank.WebApi.Extensions;
using FunctionalBank.WebApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FunctionalBank.WebApi;

internal class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) =>
    
        services
            .AddCors()
            .AddSwagger()
            .AddJwtAuthentication(_configuration)
            .AddDbContext(_configuration)
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddControllers();
    
    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment) =>
        application
            .UseCors(options => options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader())
            .OnDevelopment(() => application.UseSwagger().UseSwaggerUI(), environment)
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints.MapControllers());
}