using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using System.Linq;
using System.Linq.Expressions;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Specs {
    
    
    public class ShoplistIngredientSpecs {
        

        public static readonly Expression<Func<ShoplistIngredientInfo, SelectListShoplistIngredientCommandResult>> AsSelectListShoplistIngredientCommandResult = x => new SelectListShoplistIngredientCommandResult
				{
					Id = x.Id,
					Shoplist = x.Shoplist == null ? null : new SelectListShoplistCommandResult
					{
						Id = x.Shoplist.Id,
					},
					Ingredient = x.Ingredient == null ? null : new SelectListIngredientCommandResult
					{
						Id = x.Ingredient.Id,
						Description = x.Ingredient.Description,
					},
					AmountType = x.AmountType == null ? null : new SelectListAmountTypeCommandResult
					{
						Id = x.AmountType.Id,
						Description = x.AmountType.Description,
					}
				}
;

        public static readonly Expression<Func<ShoplistIngredientInfo, PageShoplistIngredientCommandResult>> AsPageShoplistIngredientCommandResult = x => new PageShoplistIngredientCommandResult
				{
					Id = x.Id,
					Shoplist = x.Shoplist == null ? null : new SelectListShoplistCommandResult
					{
						Id = x.Shoplist.Id,

					},
					Ingredient = x.Ingredient == null ? null : new SelectListIngredientCommandResult
					{
						Id = x.Ingredient.Id,
						Description = x.Ingredient.Description,
					},
					AmountType = x.AmountType == null ? null : new SelectListAmountTypeCommandResult
					{
						Id = x.AmountType.Id,
						Description = x.AmountType.Description,
					}
				}
;

        public static readonly Expression<Func<ShoplistIngredientInfo, ShoplistIngredientCommandResult>> AsShoplistIngredientCommandResult = x => new ShoplistIngredientCommandResult
				{
					Id = x.Id,
					Shoplist = x.Shoplist == null ? null : new ShoplistCommandResult
					{
						Id = x.Shoplist.Id,
					},
					Ingredient = x.Ingredient == null ? null : new IngredientCommandResult
					{
						Id = x.Ingredient.Id,
						Description = x.Ingredient.Description,
					},
					AmountType = x.AmountType == null ? null : new AmountTypeCommandResult
					{
						Id = x.AmountType.Id,
						Description = x.AmountType.Description,
					}
				}
;
public static Expression<Func<ShoplistIngredientInfo, bool>> TextToSearch(string textToSearch)
            {
                return x => (true); }
    }
}
