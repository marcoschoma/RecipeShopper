using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Commands.Handlers;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Services;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Shared.Application;

namespace MBC.RecipeShopper.Dbo.Application.Services {
    
    
    public class RecipeApplicationService : ApplicationService, IRecipeApplicationService {
        
        private IRecipeRepository _repository;
        
        private RecipeCommandHandler _handler;
        
        public RecipeApplicationService(IUnitOfWork uow, IRecipeRepository repository, RecipeCommandHandler handler) : 
                base(uow) {
			this._handler = handler;
			this._repository = repository;
        }
        
        public virtual async Task<NotificationResult> InsertAsync(InsertRecipeCommand command) {
			BeginTransaction();
			var result = await _handler.InsertAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> UpdateAsync(UpdateRecipeCommand command) {
			BeginTransaction();
			var result = await _handler.UpdateAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> DeleteByIdAsync(int id) {
			BeginTransaction();
			var result = await _handler.DeleteByIdAsync(id);
			return Commit(result);
        }
        
        public virtual async Task<RecipeCommandResult> GetByIdAsync(int id) {
			return await _repository.GetByIdAsync(id);
        }
        
        public virtual async Task<IEnumerable<RecipeCommandResult>> GetAsync() {
			return await _repository.GetAsync();
        }
        
        public virtual async Task<PaginatedList<PageRecipeCommandResult>> GetPageAsync(PageRecipeCommand command) {
			return await _repository.GetPageAsync(command);
        }
        
        public virtual async Task<IEnumerable<SelectListRecipeCommandResult>> GetSelectListAsync() {
			return await _repository.GetSelectListAsync();
        }
    }
}
