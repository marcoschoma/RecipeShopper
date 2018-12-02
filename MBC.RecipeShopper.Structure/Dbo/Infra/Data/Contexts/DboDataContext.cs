using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Infra.Data.Mappings.AmountType;
using MBC.RecipeShopper.Dbo.Infra.Data.Mappings.Ingredient;
using MBC.RecipeShopper.Dbo.Infra.Data.Mappings.Recipe;
using MBC.RecipeShopper.Dbo.Infra.Data.Mappings.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Infra.Data.Mappings.Shoplist;
using MBC.RecipeShopper.Dbo.Infra.Data.Mappings.ShoplistIngredient;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using MBC.RecipeShopper.Shared.Infra.Data.Contexts;

namespace MBC.RecipeShopper.Dbo.Infra.Data.Contexts
{
    public class DboDataContext : DataContext
	{
		private DbConnection _conn;
		
		public DboDataContext(IUnitOfWork uow)
		{
			_conn = uow.Connection;
			uow.AddContext(this);
			InitConfigurations();
		}

        public DbSet<AmountTypeInfo> AmountType { get; set; }
        public DbSet<IngredientInfo> Ingredient { get; set; }
        public DbSet<RecipeInfo> Recipe { get; set; }
        public DbSet<RecipeIngredientInfo> RecipeIngredient { get; set; }
        public DbSet<ShoplistInfo> Shoplist { get; set; }
        public DbSet<ShoplistIngredientInfo> ShoplistIngredient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_conn);
		}
		
		protected override void OnModelCreating(ModelBuilder builder)
		{
			RegisterMaps(builder);
		}
		
		public static void RegisterMaps(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new AmountTypeMap());
			builder.ApplyConfiguration(new IngredientMap());
			builder.ApplyConfiguration(new RecipeMap());
			builder.ApplyConfiguration(new RecipeIngredientMap());
			builder.ApplyConfiguration(new ShoplistMap());
			builder.ApplyConfiguration(new ShoplistIngredientMap());
		}
	}
}