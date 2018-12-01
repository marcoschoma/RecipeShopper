using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Services {
    
    
    public interface IShoplistApplicationService {
        
        Task<NotificationResult> InsertAsync(InsertShoplistCommand command);
        
        Task<NotificationResult> UpdateAsync(UpdateShoplistCommand command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<ShoplistCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<ShoplistCommandResult>> GetAsync();
        
        Task<PaginatedList<PageShoplistCommandResult>> GetPageAsync(PageShoplistCommand command);
        
        Task<IEnumerable<SelectListShoplistCommandResult>> GetSelectListAsync();
    }
}
