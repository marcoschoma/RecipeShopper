using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Services {
    
    
    public interface IIngredientApplicationService {
        
        Task<NotificationResult> InsertAsync(InsertIngredientCommand command);
        
        Task<NotificationResult> UpdateAsync(UpdateIngredientCommand command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<IngredientCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<IngredientCommandResult>> GetAsync();
        
        Task<PaginatedList<PageIngredientCommandResult>> GetPageAsync(PageIngredientCommand command);
        
        Task<IEnumerable<SelectListIngredientCommandResult>> GetSelectListAsync();
    }
}
