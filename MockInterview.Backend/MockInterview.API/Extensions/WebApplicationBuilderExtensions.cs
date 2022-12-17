using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MockInterview.API.Filters;
using MockInterview.BLL.Services.EntityServices;
using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Constants;
using MockInterview.Core.Extensions;
using MockInterview.DAL.Contexts;
using MockInterview.DAL.Repositories;
using MockInterview.DAL.Repositories.interfaces;
using Newtonsoft.Json;

namespace MockInterview.API.Extensions;

/// <summary>
/// Provides extension methods for Web App Builder
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Gets Db set entity types form Db Context
    /// </summary>
    /// <returns>List entity types</returns>
    private static List<Type> GetDbSetTypes() =>
        typeof(ApplicationDbContext).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.PropertyType.InheritsOrImplements(typeof(DbSet<>)))
            .Select(x => x.PropertyType.GenericTypeArguments.First())
            .ToList();

    /// <summary>
    /// Registers Database contexts to Service Collection
    /// </summary>
    /// <param name="builder">Web App Builder</param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddDbContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(AppConstants.MainDatabaseName)));
        return builder;
    }

    /// <summary>
    /// Registers Entity Repositories to Service Collection
    /// </summary>
    /// <param name="builder">Web App Builder</param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddEntityRepositories(this WebApplicationBuilder builder)
    {
        var repoType = typeof(IRepositoryBase<>);
        var targetType = typeof(RepositoryBase<>);

        GetDbSetTypes()
            .ForEach(x =>
            {
                var specificInterface = repoType.MakeGenericType(x);
                var specificImplementation = targetType.MakeGenericType(x);
                builder.Services.AddScoped(repoType, targetType);
            });

        return builder;
    }

    /// <summary>
    /// Registers Entity Services to Service Collections
    /// </summary>
    /// <param name="builder"></param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddEntityServices(this WebApplicationBuilder builder)
    {
        // Add Base Entity services
        var repoType = typeof(IRepositoryBase<>);
        var serviceType = typeof(IEntityServiceBase<>);
        var targetType = typeof(EntityServiceBase<,>);

        GetDbSetTypes()
            .ForEach(x =>
            {
                var specificInterface = serviceType.MakeGenericType(x);
                var specificRepoInterface = repoType.MakeGenericType(x);
                var specificImplementation = targetType.MakeGenericType(x, specificRepoInterface);
                builder.Services.AddScoped(specificInterface, specificImplementation);
            });

        // Add converters
        builder.Services.AddAutoMapper(typeof(Program));
        
        //Add specific Entity services
        builder.Services.AddScoped<IUserService, UserService>()
            .AddScoped<IContactService, ContactService>()
            .AddScoped<ITalentService, TalentService>()
            .AddScoped<IInterviewerService, InterviewerService>()
            .AddScoped<IIntervieweeService, IntervieweeService>();
        
        return builder;
    }
    
    /// <summary>
    /// Registers Business Logic Services to Service Collections
    /// </summary>
    /// <param name="builder"></param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddBllServices(this WebApplicationBuilder builder)
    {
        return builder;
    }

    /// <summary>
    /// Registers Entity Validation Services to Service Collections
    /// </summary>
    /// <param name="builder"></param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddValidations(this WebApplicationBuilder builder)
    {
        return builder;
    }

    /// <summary>
    /// Registers Configuration objects to Service Collection
    /// </summary>
    /// <param name="builder">Web App Builder</param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        return builder;
    }

    /// <summary>
    /// Registers Routing with custom options
    /// </summary>
    /// <param name="builder">Web App Builder</param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddCustomRouting(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => { options.LowercaseUrls = true; });

        return builder;
    }

    /// <summary>
    /// Registers Controllers with custom options
    /// </summary>
    /// <param name="builder">Web App Builder</param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddCustomControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options => { options.Filters.Add(new ExceptionFilter()); })
            .AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

        return builder;
    }

    /// <summary>
    /// Registers Open API tools to service collections
    /// </summary>
    /// <param name="builder">Web App Builder</param>
    /// <returns>Web App Builder for method chaining</returns>
    public static WebApplicationBuilder AddOpenApiTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerDocument(config =>
        {
            config.PostProcess = document =>
            {
                document.Info.Title = "Mock Interview API";
                document.Info.Version = "v1";
                document.Info.Description = "Mock Interview API Documentation";
            };
        });

        return builder;
    }
}