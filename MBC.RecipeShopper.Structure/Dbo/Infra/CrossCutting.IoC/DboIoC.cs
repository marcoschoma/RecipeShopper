using MBC.RecipeShopper.Shared.Infra.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Dbo.Infra.CrossCutting.IoC
{
    public sealed class DboIoC
    {
        public static void Register(IServiceCollection services)
        {
            DataContext.Register(services);
            Repository.Register(services);
            CommandHandler.Register(services);
            ApplicationService.Register(services);
        }
    }
}
