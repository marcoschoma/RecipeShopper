using MBC.RecipeShopper.Dbo.Infra.CrossCutting.IoC;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.StartupConfiguration.DI
{
    public sealed class IoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            DboIoC.Register(services);
        }
    }
}
