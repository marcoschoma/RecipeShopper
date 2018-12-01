using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Services {
    
    
    public interface IRecipeIngredientApplicationService {
        
        Task<NotificationResult> InsertAsync(InsertRecipeIngredientCommand command);
        
        Task<NotificationResult> UpdateAsync(UpdateRecipeIngredientCommand command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<RecipeIngredientCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<RecipeIngredientCommandResult>> GetAsync();
        
        Task<PaginatedList<PageRecipeIngredientCommandResult>> GetPageAsync(PageRecipeIngredientCommand command);
        
        Task<IEnumerable<SelectListRecipeIngredientCommandResult>> GetSelectListAsync();
    }
}
