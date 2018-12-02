using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Handlers {
    
    
    public class RecipeIngredientCommandHandler : ICommandHandler {
        
        private IRecipeIngredientRepository _recipeIngredientRepository;
        
        public RecipeIngredientCommandHandler(IRecipeIngredientRepository recipeIngredientRepository) {
            _recipeIngredientRepository = recipeIngredientRepository;
        }
        
        public virtual async Task<NotificationResult> InsertAsync(InsertRecipeIngredientCommand command) {
			var result = new NotificationResult();
			var item = new RecipeIngredientInfo(command);
			result.Add(item.GetNotificationResult());
			if (!result.IsValid)
				return result;
			result.Add(await _recipeIngredientRepository.InsertAsync(item));
			if (result.IsValid)
			{
			   result.Data = item.Id;
				result.AddMessage(Shared.Domain.Resources.Handler.InsertSuccess_Message);
			}
			else
				result.AddErrorOnTop(Shared.Domain.Resources.Handler.InsertError_Message);
			return result;
        }
        
        public virtual async Task<NotificationResult> UpdateAsync(UpdateRecipeIngredientCommand command) {
			var result = new NotificationResult();
			var item = new RecipeIngredientInfo(command);
			result.Add(item.GetNotificationResult());
			if (!result.IsValid)
			    return result;
			result.Add(await _recipeIngredientRepository.UpdateAsync(item));
			if (result.IsValid)
			{
			   result.Data = item.Id;
			    result.AddMessage(Shared.Domain.Resources.Handler.UpdateSuccess_Message);
			}
			else
			    result.AddErrorOnTop(Shared.Domain.Resources.Handler.UpdateError_Message);
			
			return result;
        }
        
        public virtual async Task<NotificationResult> DeleteByIdAsync(int id) {
			var result = new NotificationResult();
			result.Add(await _recipeIngredientRepository.DeleteByIdAsync(id));
			if (result.IsValid)
			    result.AddMessage(Shared.Domain.Resources.Handler.DeleteSuccess_Message);
			else
			    result.AddErrorOnTop(Shared.Domain.Resources.Handler.DeleteError_Message);
			return result;
        }
    }
}
