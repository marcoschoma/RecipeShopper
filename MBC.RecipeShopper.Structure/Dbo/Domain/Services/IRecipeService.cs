using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Recipe;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Services {
    
    
    public interface IRecipeApplicationService {
        
        Task<NotificationResult> InsertAsync(InsertRecipeCommand command);
        
        Task<NotificationResult> UpdateAsync(UpdateRecipeCommand command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<RecipeCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<RecipeCommandResult>> GetAsync();
        
        Task<PaginatedList<PageRecipeCommandResult>> GetPageAsync(PageRecipeCommand command);
        
        Task<IEnumerable<SelectListRecipeCommandResult>> GetSelectListAsync();
    }
}
