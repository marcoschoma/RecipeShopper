using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBCTech.RecipeShopper.Shared.Domain.Repositories;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo.Domain.Comum;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Repositories {
    
    
    public interface IAmountTypeRepository : IRepository<AmountTypeInfo> {
        
        Task<NotificationResult> InsertAsync(AmountTypeInfo command);
        
        Task<NotificationResult> UpdateAsync(AmountTypeInfo command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<AmountTypeCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<AmountTypeCommandResult>> GetAsync();
        
        Task<PaginatedList<PageAmountTypeCommandResult>> GetPageAsync(PageAmountTypeCommand command);
        
        Task<IEnumerable<SelectListAmountTypeCommandResult>> GetSelectListAsync();
    }
}
