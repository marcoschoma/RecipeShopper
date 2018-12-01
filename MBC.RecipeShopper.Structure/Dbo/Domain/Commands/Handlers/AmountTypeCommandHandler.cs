using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Repositories;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Commands.Handlers {
    
    
    public class AmountTypeCommandHandler : ICommandHandler {
        
        private IAmountTypeRepository _amountTypeRepository;
        
        private IRecipeIngredientRepository _recipeIngredientRepository;
        
        private IShoplistIngredientRepository _shoplistIngredientRepository;
        
        public AmountTypeCommandHandler(IAmountTypeRepository amountTypeRepository, IRecipeIngredientRepository recipeIngredientRepository, IShoplistIngredientRepository shoplistIngredientRepository) {
            _amountTypeRepository = amountTypeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
            _shoplistIngredientRepository = shoplistIngredientRepository;
        }
        
        public virtual async Task<NotificationResult> InsertAsync(InsertAmountTypeCommand command) {
			var result = new NotificationResult();
			var item = new AmountTypeInfo(command);
			result.Add(item.GetNotificationResult());
			if (!result.IsValid)
				return result;
			result.Add(await _amountTypeRepository.InsertAsync(item));
			if (result.IsValid)
			{
			   result.Data = item.Id;
				result.AddMessage(Shared.Domain.Resources.Handler.InsertSuccess_Message);
			}
			else
				result.AddErrorOnTop(Shared.Domain.Resources.Handler.InsertError_Message);
			return result;
        }
        
        public virtual async Task<NotificationResult> UpdateAsync(UpdateAmountTypeCommand command) {
			var result = new NotificationResult();
			var item = new AmountTypeInfo(command);
			result.Add(item.GetNotificationResult());
			if (!result.IsValid)
			    return result;
			result.Add(await _amountTypeRepository.UpdateAsync(item));
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
			result.Add(await _shoplistIngredientRepository.DeleteByIdAsync(id));
			result.Add(await _amountTypeRepository.DeleteByIdAsync(id));
			if (result.IsValid)
			    result.AddMessage(Shared.Domain.Resources.Handler.DeleteSuccess_Message);
			else
			    result.AddErrorOnTop(Shared.Domain.Resources.Handler.DeleteError_Message);
			return result;
        }
    }
}
