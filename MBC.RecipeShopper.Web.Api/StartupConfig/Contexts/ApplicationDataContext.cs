using MBC.RecipeShopper.Shared.Infra.Data.Contexts;
using System;
using Microsoft.EntityFrameworkCore;
using MBC.RecipeShopper.Shared.Settings;
using MBC.RecipeShopper.Dbo.Infra.Data.Contexts;

namespace MBC.RecipeShopper.StartupConfiguration.Contexts
{
    public class ApplicationDataContext : DataContext
    {
        public ApplicationDataContext()
        {
            InitConfigurations();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionStrings.DefaultConnection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RegisterMaps(builder);
        }

        private void RegisterMaps(ModelBuilder builder)
        {
            DboDataContext.RegisterMaps(builder);
        }
    }
}
