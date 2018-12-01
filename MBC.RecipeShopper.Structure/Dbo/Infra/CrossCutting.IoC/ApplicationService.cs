using MBCTech.RecipeShopper.Dbo.Application.Services;
using MBCTech.RecipeShopper.Dbo.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MBCTech.RecipeShopper.Dbo.Infra.CrossCutting.IoC
{
    internal class ApplicationService
	{
		public static void Register(IServiceCollection services)
		{
			services.AddTransient<IRecipeIngredientApplicationService, RecipeIngredientApplicationService>();
            services.AddTransient<IShoplistApplicationService, ShoplistApplicationService>();
            services.AddTransient<IShoplistIngredientApplicationService, ShoplistIngredientApplicationService>();
        }
	}
}
