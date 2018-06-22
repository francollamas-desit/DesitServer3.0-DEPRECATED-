using Desit.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Desit.Services
{
    /**
     * Extensiónes de Servicios
     */
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, Assembly assembly = null)
        {
            Assembly ass = assembly ?? Assembly.GetEntryAssembly();


            Type[] assemblieTypesNameContaintContext = (from type in ass.GetTypes()
                                                        where type.IsClass && type.BaseType.Name == typeof(Repository<>).Name
                                                        select type).ToArray();

            foreach (Type type in assemblieTypesNameContaintContext)
            {
                services.AddSingleton(type);
            }

            return services;
        }
    }
}
