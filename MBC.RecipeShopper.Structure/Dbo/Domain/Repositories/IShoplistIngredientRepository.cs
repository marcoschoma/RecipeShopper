using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
using MBCTech.RecipeShopper.Shared.Domain.Repositories;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo.Domain.Comum;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Repositories {
    
    
    public interface IShoplistIngredientRepository : IRepository<ShoplistIngredientInfo> {
        
        Task<NotificationResult> InsertAsync(ShoplistIngredientInfo command);
        
        Task<NotificationResult> UpdateAsync(ShoplistIngredientInfo command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<ShoplistIngredientCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<ShoplistIngredientCommandResult>> GetAsync();
        
        Task<PaginatedList<PageShoplistIngredientCommandResult>> GetPageAsync(PageShoplistIngredientCommand command);
        
        Task<IEnumerable<SelectListShoplistIngredientCommandResult>> GetSelectListAsync();
    }
}
