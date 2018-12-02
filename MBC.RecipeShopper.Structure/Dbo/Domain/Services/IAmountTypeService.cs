using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Services {
    
    
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
