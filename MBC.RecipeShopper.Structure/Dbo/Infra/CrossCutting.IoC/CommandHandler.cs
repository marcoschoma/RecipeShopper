using Microsoft.Extensions.DependencyInjection;
using MBC.RecipeShopper.Dbo.Domain.Commands.Handlers;

namespace MBC.RecipeShopper.Dbo.Infra.CrossCutting.IoC
{
	internal class CommandHandler
	{
		public static void Register(IServiceCollection services)
		{
			services.AddTransient<AmountTypeCommandHandler, AmountTypeCommandHandler>();
			services.AddTransient<IngredientCommandHandler, IngredientCommandHandler>();
			services.AddTransient<RecipeCommandHandler, RecipeCommandHandler>();
			services.AddTransient<RecipeIngredientCommandHandler, RecipeIngredientCommandHandler>();
            services.AddTransient<ShoplistCommandHandler, ShoplistCommandHandler>();
            services.AddTransient<ShoplistIngredientCommandHandler, ShoplistIngredientCommandHandler>();}
	}
}
//moises Alteração