using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Services {
    
    
    public interface IAmountTypeApplicationService {
        
        Task<NotificationResult> InsertAsync(InsertAmountTypeCommand command);
        
        Task<NotificationResult> UpdateAsync(UpdateAmountTypeCommand command);
        
        Task<NotificationResult> DeleteByIdAsync(int id);
        
        Task<AmountTypeCommandResult> GetByIdAsync(int id);
        
        Task<IEnumerable<AmountTypeCommandResult>> GetAsync();
        
        Task<PaginatedList<PageAmountTypeCommandResult>> GetPageAsync(PageAmountTypeCommand command);
        
        Task<IEnumerable<SelectListAmountTypeCommandResult>> GetSelectListAsync();
    }
}
