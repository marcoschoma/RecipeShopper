using MBC.RecipeShopper.Dbo.Application.Services;
using MBC.RecipeShopper.Dbo.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MBC.RecipeShopper.Dbo.Infra.CrossCutting.IoC
{
    internal class ApplicationService
	{
		public static void Register(IServiceCollection services)
		{
            services.AddTransient<IAmountTypeApplicationService, AmountTypeApplicationService>();
            services.AddTransient<IIngredientApplicationService, IngredientApplicationService>();
            services.AddTransient<IRecipeApplicationService, RecipeApplicationService>();
            services.AddTransient<IRecipeIngredientApplicationService, RecipeIngredientApplicationService>();
            services.AddTransient<IShoplistApplicationService, ShoplistApplicationService>();
            services.AddTransient<IShoplistIngredientApplicationService, ShoplistIngredientApplicationService>();
        }
	}
}
