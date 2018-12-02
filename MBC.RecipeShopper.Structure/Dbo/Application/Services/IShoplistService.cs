using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Commands.Handlers;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Services;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Shared.Application;

namespace MBC.RecipeShopper.Dbo.Application.Services {
    
    
    public class ShoplistApplicationService : ApplicationService, IShoplistApplicationService {
        
        private IShoplistRepository _repository;
        
        private ShoplistCommandHandler _handler;
        
        public ShoplistApplicationService(IUnitOfWork uow, IShoplistRepository repository, ShoplistCommandHandler handler) : 
                base(uow) {
			this._handler = handler;
			this._repository = repository;
        }
        
        public virtual async Task<NotificationResult> InsertAsync(InsertShoplistCommand command) {
			BeginTransaction();
			var result = await _handler.InsertAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> UpdateAsync(UpdateShoplistCommand command) {
			BeginTransaction();
			var result = await _handler.UpdateAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> DeleteByIdAsync(int id) {
			BeginTransaction();
			var result = await _handler.DeleteByIdAsync(id);
			return Commit(result);
        }
        
        public virtual async Task<ShoplistCommandResult> GetByIdAsync(int id) {
			return await _repository.GetByIdAsync(id);
        }
        
        public virtual async Task<IEnumerable<ShoplistCommandResult>> GetAsync() {
			return await _repository.GetAsync();
        }
        
        public virtual async Task<PaginatedList<PageShoplistCommandResult>> GetPageAsync(PageShoplistCommand command) {
			return await _repository.GetPageAsync(command);
        }
        
        public virtual async Task<IEnumerable<SelectListShoplistCommandResult>> GetSelectListAsync() {
			return await _repository.GetSelectListAsync();
        }
    }
}
