using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Services {
    
    
    public interface IShoplistIngredientApplicationService {
        
        Task<NotificationResult> InsertAsync(InsertShoplistIngredientCommand command);
        
        Task<NotificationResult> UpdateAsync(UpdateShoplistIngredientCommand command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<ShoplistIngredientCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<ShoplistIngredientCommandResult>> GetAsync();
        
        Task<PaginatedList<PageShoplistIngredientCommandResult>> GetPageAsync(PageShoplistIngredientCommand command);
        
        Task<IEnumerable<SelectListShoplistIngredientCommandResult>> GetSelectListAsync();
    }
}
