using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Handlers;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Repositories;
using MBCTech.RecipeShopper.Dbo.Domain.Services;
using MBCTech.RecipeShopper.Shared.Application.Services;
using MBCTech.RecipeShopper.Shared.Infra.Data.Transactions;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Application.Services {
    
    
    public class AmountTypeApplicationService : ApplicationService, IAmountTypeApplicationService {
        
        private IAmountTypeRepository _repository;
        
        private AmountTypeCommandHandler _handler;
        
        public AmountTypeApplicationService(IUnitOfWork uow, IAmountTypeRepository repository, AmountTypeCommandHandler handler) : 
                base(uow) {
			this._handler = handler;
			this._repository = repository;
        }
        
        public virtual async Task<NotificationResult> InsertAsync(InsertAmountTypeCommand command) {
			BeginTransaction();
			var result = await _handler.InsertAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> UpdateAsync(UpdateAmountTypeCommand command) {
			BeginTransaction();
			var result = await _handler.UpdateAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> DeleteByIdAsync(int id) {
			BeginTransaction();
			var result = await _handler.DeleteByIdAsync(id);
			return Commit(result);
        }
        
        public virtual async Task<AmountTypeCommandResult> GetByIdAsync(int id) {
			return await _repository.GetByIdAsync(id);
        }
        
        public virtual async Task<IEnumerable<AmountTypeCommandResult>> GetAsync() {
			return await _repository.GetAsync();
        }
        
        public virtual async Task<PaginatedList<PageAmountTypeCommandResult>> GetPageAsync(PageAmountTypeCommand command) {
			return await _repository.GetPageAsync(command);
        }
        
        public virtual async Task<IEnumerable<SelectListAmountTypeCommandResult>> GetSelectListAsync() {
			return await _repository.GetSelectListAsync();
        }
    }
}
