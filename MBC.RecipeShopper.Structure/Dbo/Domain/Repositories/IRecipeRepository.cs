using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Recipe;
using MBC.RecipeShopper.Shared.Domain.Repositories;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;

using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Repositories {
    
    
    public interface IRecipeRepository : IRepository<RecipeInfo> {
        
        Task<NotificationResult> InsertAsync(RecipeInfo command);
        
        Task<NotificationResult> UpdateAsync(RecipeInfo command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<RecipeCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<RecipeCommandResult>> GetAsync();
        
        Task<PaginatedList<PageRecipeCommandResult>> GetPageAsync(PageRecipeCommand command);
        
        Task<IEnumerable<SelectListRecipeCommandResult>> GetSelectListAsync();
    }
}
