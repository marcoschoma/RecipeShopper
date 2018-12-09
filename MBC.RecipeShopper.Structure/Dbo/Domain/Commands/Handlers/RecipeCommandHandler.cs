using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo;

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Handlers
{


    public class RecipeCommandHandler : ICommandHandler
    {

        private IRecipeRepository _recipeRepository;
        private IRecipeIngredientRepository _recipeIngredientRepository;

        public RecipeCommandHandler(IRecipeRepository recipeRepository,
            IRecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        public virtual async Task<NotificationResult> InsertAsync(InsertRecipeCommand command)
        {
            var result = new NotificationResult();
            var item = new RecipeInfo(command);
            result.Add(item.GetNotificationResult());
            if (!result.IsValid)
                return result;
            result.Add(await _recipeRepository.InsertAsync(item));

            if (result.IsValid)
            {
                if (command.RecipeIngredients != null && command.RecipeIngredients.Count > 0)
                {
                    foreach (var recipeIngredientCommand in command.RecipeIngredients)
                    {
                        var recipeIngredient = new RecipeIngredientInfo(recipeIngredientCommand);
                        recipeIngredient.SetRecipeId(item.Id.Value);
                        result.Add(await _recipeIngredientRepository.InsertAsync(recipeIngredient));
                    }   
                }

                result.Data = item.Id;
                result.AddMessage(Shared.Domain.Resources.Handler.InsertSuccess_Message);
            }
            else
                result.AddErrorOnTop(Shared.Domain.Resources.Handler.InsertError_Message);
            return result;
        }

        public virtual async Task<NotificationResult> UpdateAsync(UpdateRecipeCommand command)
        {
            var result = new NotificationResult();
            var item = new RecipeInfo(command);
            result.Add(item.GetNotificationResult());
            if (!result.IsValid)
                return result;
            result.Add(await _recipeRepository.UpdateAsync(item));
            if (result.IsValid)
            {
                result.Data = item.Id;
                result.AddMessage(Shared.Domain.Resources.Handler.UpdateSuccess_Message);
            }
            else
                result.AddErrorOnTop(Shared.Domain.Resources.Handler.UpdateError_Message);

            return result;
        }

        public virtual async Task<NotificationResult> DeleteByIdAsync(int id)
        {
            var result = new NotificationResult();
            result.Add(await _recipeRepository.DeleteByIdAsync(id));
            if (result.IsValid)
                result.AddMessage(Shared.Domain.Resources.Handler.DeleteSuccess_Message);
            else
                result.AddErrorOnTop(Shared.Domain.Resources.Handler.DeleteError_Message);
            return result;
        }
    }
}
