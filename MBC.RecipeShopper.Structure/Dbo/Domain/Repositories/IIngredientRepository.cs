using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBCTech.RecipeShopper.Shared.Domain.Repositories;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo.Domain.Comum;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Repositories {
    
    
    public interface IIngredientRepository : IRepository<IngredientInfo> {
        
        Task<NotificationResult> InsertAsync(IngredientInfo command);
        
        Task<NotificationResult> UpdateAsync(IngredientInfo command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<IngredientCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<IngredientCommandResult>> GetAsync();
        
        Task<PaginatedList<PageIngredientCommandResult>> GetPageAsync(PageIngredientCommand command);
        
        Task<IEnumerable<SelectListIngredientCommandResult>> GetSelectListAsync();
    }
}
