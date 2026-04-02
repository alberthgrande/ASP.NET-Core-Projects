using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleTaskManagerApi.Interfaces.Repositories;
using SimpleTaskManagerApi.Repositories;

namespace SimpleTaskManagerApi.Extensions;

public static class ServiceExtensions
{

    public static void AddApplicationServices(this IServiceCollection services)
    {
        // // Repositories
        services.AddScoped<ITaskRepository, TaskRepository>();
        // services.AddScoped<IProductRepository, ProductRepository>();
        // services.AddScoped<ICategoryRepository, CategoryRepository>();

        // // Services
        // services.AddScoped<IProductService, ProductService>();
        // services.AddScoped<ICategoryService, CategoryService>();
    }

}
