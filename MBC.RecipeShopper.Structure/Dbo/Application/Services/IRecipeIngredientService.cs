using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Handlers;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
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
    
    
    public class RecipeIngredientApplicationService : ApplicationService, IRecipeIngredientApplicationService {
        
        private IRecipeIngredientRepository _repository;
        
        private RecipeIngredientCommandHandler _handler;
        
        public RecipeIngredientApplicationService(IUnitOfWork uow, IRecipeIngredientRepository repository, RecipeIngredientCommandHandler handler) : 
                base(uow) {
			this._handler = handler;
			this._repository = repository;
        }
        
        public virtual async Task<NotificationResult> InsertAsync(InsertRecipeIngredientCommand command) {
			BeginTransaction();
			var result = await _handler.InsertAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> UpdateAsync(UpdateRecipeIngredientCommand command) {
			BeginTransaction();
			var result = await _handler.UpdateAsync(command);
			return Commit(result);
        }
        
        public virtual async Task<NotificationResult> DeleteByIdAsync(int id) {
			BeginTransaction();
			var result = await _handler.DeleteByIdAsync(id);
			return Commit(result);
        }
        
        public virtual async Task<RecipeIngredientCommandResult> GetByIdAsync(int id) {
			return await _repository.GetByIdAsync(id);
        }
        
        public virtual async Task<IEnumerable<RecipeIngredientCommandResult>> GetAsync() {
			return await _repository.GetAsync();
        }
        
        public virtual async Task<PaginatedList<PageRecipeIngredientCommandResult>> GetPageAsync(PageRecipeIngredientCommand command) {
			return await _repository.GetPageAsync(command);
        }
        
        public virtual async Task<IEnumerable<SelectListRecipeIngredientCommandResult>> GetSelectListAsync() {
			return await _repository.GetSelectListAsync();
        }
    }
}
