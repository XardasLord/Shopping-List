﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingList.Business;
using ShoppingList.Business.Implementation.Queries;
using ShoppingList.Business.Implementation.Services;
using ShoppingList.Business.Queries;
using ShoppingList.Business.Services;
using ShoppingList.Database;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShoppingListDependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IIngredientQuery, IngredientQuery>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IRecipeQuery, RecipeQuery>();
            services.AddTransient<IRecipeService, RecipeService>();

            services.AddDbContext<IShoppingListDbContext, ShoppingListDbContext>(
                opts => opts.UseSqlServer(configuration["ConnectionString:ShoppingListDB"],
                    b => b.MigrationsAssembly("ShoppingList.Database"))
            );

            return services;
        }
    }
}