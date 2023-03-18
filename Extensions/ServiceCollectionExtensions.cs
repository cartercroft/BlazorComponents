﻿using CroftBlazorComponents.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroftBlazorComponents.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddComponentServices(this IServiceCollection services)
        {
            services.AddTransient<ToastService>();
        }
    }
}
