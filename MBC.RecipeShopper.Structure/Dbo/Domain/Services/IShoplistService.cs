using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Services {
    
    
    public interface IShoplistApplicationService {
        
        Task<NotificationResult> InsertAsync(InsertShoplistCommand command);
        
        Task<NotificationResult> UpdateAsync(UpdateShoplistCommand command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<ShoplistCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<ShoplistCommandResult>> GetAsync();
        
        Task<PaginatedList<PageShoplistCommandResult>> GetPageAsync(PageShoplistCommand command);
        
        Task<IEnumerable<SelectListShoplistCommandResult>> GetSelectListAsync();

        Task<NotificationResult> CreateShoplistWithIngredientsAsync(InsertShoplistWithIngredientsCommand command);
    }
}
