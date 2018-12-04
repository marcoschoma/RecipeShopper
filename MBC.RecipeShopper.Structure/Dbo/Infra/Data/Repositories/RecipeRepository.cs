using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Recipe;
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
    
    
    public class RecipeRepository : Repository, IRecipeRepository {
        
        private IUnitOfWork _uow;
        
        private DboDataContext _context;
        
        public RecipeRepository(IUnitOfWork uow, DboDataContext context) : 
                base(uow, context) {
			_uow = uow;
			_context = context;
        }
        
        public async Task<NotificationResult> InsertAsync(RecipeInfo item) {
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
        
        public async Task<NotificationResult> UpdateAsync(RecipeInfo item) {
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
                await _uow.Connection.ExecuteAsync("delete from Recipe where Id = @id", new { id }, _uow.Transaction);
            }
			catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<RecipeCommandResult> GetByIdAsync(int id) {
			return await _context.Recipe
                .Include(x => x.RecipeIngredients)
                .AsNoTracking()
                .Where(x => x.Id == id)
			    .Select(RecipeSpecs.AsRecipeCommandResult)
			    .SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<RecipeCommandResult>> GetAsync() {
			return await _context.Recipe.AsNoTracking()
			    .OrderBy(x => x.Name)
			    .Select(RecipeSpecs.AsRecipeCommandResult)
			    .ToListAsync();
        }
        
        public async Task<PaginatedList<PageRecipeCommandResult>> GetPageAsync(PageRecipeCommand command) {
			var source = _context.Recipe.AsNoTracking().AsExpandable();
			var outer = PredicateBuilder.New<RecipeInfo>(true);
			
			if (!string.IsNullOrEmpty(command.TextToSearch))
			{
			    var inner = PredicateBuilder.New<RecipeInfo>();
			    inner = inner.Start(RecipeSpecs.TextToSearch(command.TextToSearch));
			    outer = outer.And(inner);
			}
			
			var count = await source.Where(outer).CountAsync();
			var items = await source.Where(outer)
			    .Skip(command.SkipNumber)
			    .Take(command.PageSize)
			    .Select(RecipeSpecs.AsPageRecipeCommandResult)
			    .ToListAsync();
			
			return new PaginatedList<PageRecipeCommandResult>(items, count, command.PageNumber, command.PageSize);
        }
        
        public async Task<IEnumerable<SelectListRecipeCommandResult>> GetSelectListAsync() {
			return await _context.Recipe.AsNoTracking()
			    .OrderBy(x => x.Name)
			    .Select(RecipeSpecs.AsSelectListRecipeCommandResult)
			    .ToListAsync();
        }
    }
}
