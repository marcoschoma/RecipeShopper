using MBC.RecipeShopper.Dbo.Infra.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Dbo.Infra.CrossCutting.IoC
{
    internal class DataContext
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<DboDataContext, DboDataContext>();
        }
    }
}
