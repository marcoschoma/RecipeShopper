using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Linq;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;

namespace MBC.RecipeShopper.Dbo.Domain.Specs
{

    public class RecipeSpecs
    {

        public static readonly Expression<Func<RecipeInfo, SelectListRecipeCommandResult>> AsSelectListRecipeCommandResult = x => new SelectListRecipeCommandResult
        {
            Id = x.Id,
            Name = x.Name,
            Steps = x.Steps,
        };

        public static readonly Expression<Func<RecipeInfo, PageRecipeCommandResult>> AsPageRecipeCommandResult = x => new PageRecipeCommandResult
        {
            Id = x.Id,
            Name = x.Name,
            Steps = x.Steps,
        };

        public static readonly Expression<Func<RecipeInfo, RecipeCommandResult>> AsRecipeCommandResult = x => new RecipeCommandResult
        {
            Id = x.Id,
            Name = x.Name,
            Steps = x.Steps,
            RecipeIngredients = x.RecipeIngredients.Select(ri => new RecipeIngredientCommandResult()
            {
                Amount = ri.Amount,
                AmountTypeId = ri.AmountTypeId,
                IngredientId = ri.IngredientId,
                Ingredient = ri.Ingredient == null ? null : new IngredientCommandResult
                {
                    Description = ri.Ingredient.Description
                },
                AmountType = ri.AmountType == null ? null : new AmountTypeCommandResult
                {
                    Description = ri.AmountType.Description
                }
            }).ToList()
        };

        public static Expression<Func<RecipeInfo, bool>> TextToSearch(string textToSearch)
        {
            return x => (x.Name.Contains(textToSearch) || x.Steps.Contains(textToSearch));
        }
    }
}
