using EcommercePersistence;
using EcommerceService;
using EcommerceService.Helpers;
using LMS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Runtime.Loader;

namespace LMS.Service;

class Program
{
    static void Main(string[] args)
    {
        var files = Directory.GetFiles(
            AppDomain.CurrentDomain.BaseDirectory,
            "Ecommerce*.dll");

        var assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegisterAuthentication(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lms", Version = "v1" });
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://sso-sts.gjirafa.dev/connect/authorize"),
                        TokenUrl = new Uri("https://sso-sts.gjirafa.dev/connect/token"),
                        Scopes = new Dictionary<string, string> { { "life_2024_api", "LifeApi" } }
                    }
                }
            });
            c.DocumentFilter<LowercaseDocumentFilter>();
            c.OperationFilter<AuthorizeCheckOperationFilter>();
        }
);

        builder.Services.AddAdvancedDependencyInjection();

        builder.Services.Scan(p => p.FromAssemblies(assemblies)
            .AddClasses()
            .AsMatchingInterface());

        builder.Services.AddDbContext<DatabaseService>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DisplayRequestDuration();
                c.DefaultModelExpandDepth(0);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Life Ecommerce");
                c.OAuthClientId("d8ce3b13-d539-4816-8d07-b1e4c7087fda");
                c.OAuthClientSecret("4a9db740-2460-471a-b3a1-6d86bb99b279");
                c.OAuthAppName("Life Ecommerce");
                c.OAuthUsePkce();
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.UseAdvancedDependencyInjection();

        app.Run();
    }
}