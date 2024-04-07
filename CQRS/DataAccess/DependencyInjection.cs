using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
    

    namespace DataAccess
    {
        public static class DependencyInjection
        {
            public static IServiceCollection AddDataAccess(this IServiceCollection services)
            {
                services.AddSingleton<IProductDatabase,ProductDatabase>();
                return services;
            }

        }
    }
