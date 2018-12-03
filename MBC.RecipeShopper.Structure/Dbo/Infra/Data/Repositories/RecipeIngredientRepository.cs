using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Domain.Specs;
using MBC.RecipeShopper.Dbo.Infra.Data.Contexts;
using MBC.RecipeShopper.Shared.Infra.Data.Repositories;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using Dapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using MBC.RecipeShopper.Shared.Domain.Commands;

using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Infra.Data.Repositories {
    
    
    public class RecipeIngredientRepository : Repository, IRecipeIngredientRepository {
        
        private IUnitOfWork _uow;
        
        private DboDataContext _context;
        
        public RecipeIngredientRepository(IUnitOfWork uow, DboDataContext context) : 
                base(uow, context) {
			_uow = uow;
			_context = context;
        }
        
        public async Task<NotificationResult> InsertAsync(RecipeIngredientInfo item) {
			var result = new NotificationResult();
			try
			{
                await _context.AddAsync(item);
                item.SetId(_context.SaveChanges());
            }
			catch(Exception ex)
			{
				result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<NotificationResult> UpdateAsync(RecipeIngredientInfo item) {
			var result = new NotificationResult();
			
			try
			{
                _context.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
			catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<NotificationResult> DeleteByIdAsync(int id) {
			var result = new NotificationResult();
			try
			{
                await _uow.Connection.ExecuteAsync("delete from RecipeIngredient where Id = @id", new { id }, _uow.Transaction);
            }
			catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<RecipeIngredientCommandResult> GetByIdAsync(int id) {
			return await _context.RecipeIngredient.AsNoTracking()
			    .Where(x => x.Id == id)
			    .Select(RecipeIngredientSpecs.AsRecipeIngredientCommandResult)
			    .SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<RecipeIngredientCommandResult>> GetAsync() {
			return await _context.RecipeIngredient.AsNoTracking()
			    .Include(x => x.Ingredient)
			    .Include(x => x.AmountType)
			    .Select(RecipeIngredientSpecs.AsRecipeIngredientCommandResult)
			    .ToListAsync();
        }
        
        public async Task<PaginatedList<PageRecipeIngredientCommandResult>> GetPageAsync(PageRecipeIngredientCommand command) {
			var source = _context.RecipeIngredient.AsNoTracking().AsExpandable();
			var outer = PredicateBuilder.New<RecipeIngredientInfo>(true);
			
			if (command.IngredientId.Any())
			    outer = outer.Start(x => command.IngredientId.Contains(x.IngredientId.Value));
			
			if (command.AmountTypeId.Any())
			    outer = outer.Start(x => command.AmountTypeId.Contains(x.AmountTypeId.Value));
			
			if (!string.IsNullOrEmpty(command.TextToSearch))
			{
			    var inner = PredicateBuilder.New<RecipeIngredientInfo>();
			    inner = inner.Start(RecipeIngredientSpecs.TextToSearch(command.TextToSearch));
			    outer = outer.And(inner);
			}
			
			var count = await source.Where(outer).CountAsync();
			var items = await source.Where(outer)
			    .Skip(command.SkipNumber)
			    .Take(command.PageSize)
			    .Include(x => x.Ingredient)
			    .Include(x => x.AmountType)
			    .Select(RecipeIngredientSpecs.AsPageRecipeIngredientCommandResult)
			    .ToListAsync();
			
			return new PaginatedList<PageRecipeIngredientCommandResult>(items, count, command.PageNumber, command.PageSize);
        }
        
        public async Task<IEnumerable<SelectListRecipeIngredientCommandResult>> GetSelectListAsync() {
			return await _context.RecipeIngredient.AsNoTracking()
			    .Select(RecipeIngredientSpecs.AsSelectListRecipeIngredientCommandResult)
			    .ToListAsync();
        }
    }
}
