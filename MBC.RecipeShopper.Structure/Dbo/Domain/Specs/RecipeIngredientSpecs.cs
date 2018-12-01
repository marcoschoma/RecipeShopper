using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using System.Linq;
using System.Linq.Expressions;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Specs {
    
    
    public class RecipeIngredientSpecs {
        

        public static readonly Expression<Func<RecipeIngredientInfo, SelectListRecipeIngredientCommandResult>> AsSelectListRecipeIngredientCommandResult = x => new SelectListRecipeIngredientCommandResult
				{
					Id = x.Id,
					Ingredient = x.Ingredient == null ? null : new SelectListIngredientCommandResult
					{
						Id = x.Ingredient.Id,
						Description = x.Ingredient.Description,
					}
					AmountType = x.AmountType == null ? null : new SelectListAmountTypeCommandResult
					{
						Id = x.AmountType.Id,
						Description = x.AmountType.Description,
					}
				}
;

        public static readonly Expression<Func<RecipeIngredientInfo, PageRecipeIngredientCommandResult>> AsPageRecipeIngredientCommandResult = x => new PageRecipeIngredientCommandResult
				{
					Id = x.Id,
					Ingredient = x.Ingredient == null ? null : new SelectListIngredientCommandResult
					{
						Id = x.Ingredient.Id,
						Description = x.Ingredient.Description,
					}
					AmountType = x.AmountType == null ? null : new SelectListAmountTypeCommandResult
					{
						Id = x.AmountType.Id,
						Description = x.AmountType.Description,
					}
				}
;

        public static readonly Expression<Func<RecipeIngredientInfo, RecipeIngredientCommandResult>> AsRecipeIngredientCommandResult = x => new RecipeIngredientCommandResult
				{
					Id = x.Id,
					Ingredient = x.Ingredient == null ? null : new IngredientCommandResult
					{
						Id = x.Ingredient.Id,
						Description = x.Ingredient.Description,
					}
					AmountType = x.AmountType == null ? null : new AmountTypeCommandResult
					{
						Id = x.AmountType.Id,
						Description = x.AmountType.Description,
					}
				}
;
public static Expression<Func<RecipeIngredientInfo, bool>> TextToSearch(string textToSearch)
            {
                return x => (true); }
    }
}
