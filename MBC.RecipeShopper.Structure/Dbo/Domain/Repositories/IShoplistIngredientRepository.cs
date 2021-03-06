using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
using MBC.RecipeShopper.Shared.Domain.Repositories;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;

using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Repositories {
    
    
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
