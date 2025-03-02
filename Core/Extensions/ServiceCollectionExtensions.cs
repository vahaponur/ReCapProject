﻿
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services); 
            }

            ServiceTool.Create(services);
        }
    }
}