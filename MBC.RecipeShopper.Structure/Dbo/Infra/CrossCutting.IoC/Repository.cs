using Microsoft.Extensions.DependencyInjection;
using MBCTech.RecipeShopper.Dbo.Domain.Repositories;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Repositories;

namespace MBCTech.RecipeShopper.Dbo.Infra.CrossCutting.IoC
{
	internal class Repository
	{
		public static void Register(IServiceCollection services)
		{
			services.AddTransient<IAmountTypeRepository, AmountTypeRepository>();
			services.AddTransient<IIngredientRepository, IngredientRepository>();
			services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddTransient<IShoplistRepository, ShoplistRepository>();
            services.AddTransient<IShoplistIngredientRepository, ShoplistIngredientRepository>();}
	}
}
