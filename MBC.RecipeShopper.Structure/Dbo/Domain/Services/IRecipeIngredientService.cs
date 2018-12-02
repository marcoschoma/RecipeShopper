using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Services {
    
    
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
