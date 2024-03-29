﻿using Microsoft.Extensions.DependencyInjection;
using QueryCraft.Convertors;
using QueryCraft.Interfaces;
using QueryCraft.Parsing;
using QueryCraft.TypeConversations;
using System;

namespace QueryCraft.MVC
{
    public static class DependencyRegistrar
    {
        public static IServiceCollection RegisterQueryCraft(this IServiceCollection services, Action<QueryCraftOptions> configureOptions = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var options = new QueryCraftOptions();
            

            RegisterTypeConverter(services, options);
            RegisterOperatorConverter(services, options);
            services.AddScoped<IParser, BodyParser>();
            return services;
        }

        private static void RegisterTypeConverter(this IServiceCollection services, QueryCraftOptions options)
        {
            if (options != null && options.ConverterTypes !=  null)
            {
                services.AddTransient<ITypeConverter>(opt => new TypeConverter(options.ConverterTypes));
            }
            else 
            {
                services.AddTransient<ITypeConverter, TypeConverter>();
            }
        }

        private static void RegisterOperatorConverter(this IServiceCollection services, QueryCraftOptions options)
        {
            if (options != null && options.ConverterOperators != null)
            {
                services.AddTransient<IOperatorConverter>(opt => new OperatorConverter(opt.GetRequiredService<ITypeConverter>(), options.ConverterOperators));
            }
            else
            {
                services.AddTransient<IOperatorConverter, OperatorConverter>();
            }
        }
    }
}
