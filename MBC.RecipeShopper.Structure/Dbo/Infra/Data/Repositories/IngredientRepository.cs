using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
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
    
    
    public class IngredientRepository : Repository, IIngredientRepository {
        
        private IUnitOfWork _uow;
        
        private DboDataContext _context;
        
        public IngredientRepository(IUnitOfWork uow, DboDataContext context) : 
                base(uow, context) {
			_uow = uow;
			_context = context;
        }
        
        public async Task<NotificationResult> InsertAsync(IngredientInfo item) {
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
        
        public async Task<NotificationResult> UpdateAsync(IngredientInfo item) {
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
                await _uow.Connection.ExecuteAsync("delete from Ingredient where Id = @id", new { id }, _uow.Transaction);
            }
			catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<IngredientCommandResult> GetByIdAsync(int id) {
			return await _context.Ingredient.AsNoTracking()
			    .Where(x => x.Id == id)
			    .Select(IngredientSpecs.AsIngredientCommandResult)
			    .SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<IngredientCommandResult>> GetAsync() {
			return await _context.Ingredient.AsNoTracking()
			    .OrderBy(x => x.Description)
			    .Select(IngredientSpecs.AsIngredientCommandResult)
			    .ToListAsync();
        }
        
        public async Task<PaginatedList<PageIngredientCommandResult>> GetPageAsync(PageIngredientCommand command) {
			var source = _context.Ingredient.AsNoTracking().AsExpandable();
			var outer = PredicateBuilder.New<IngredientInfo>(true);
			
			if (!string.IsNullOrEmpty(command.TextToSearch))
			{
			    var inner = PredicateBuilder.New<IngredientInfo>();
			    inner = inner.Start(IngredientSpecs.TextToSearch(command.TextToSearch));
			    outer = outer.And(inner);
			}
			
			var count = await source.Where(outer).CountAsync();
			var items = await source.Where(outer)
			    .Skip(command.SkipNumber)
			    .Take(command.PageSize)
			    .Select(IngredientSpecs.AsPageIngredientCommandResult)
			    .ToListAsync();
			
			return new PaginatedList<PageIngredientCommandResult>(items, count, command.PageNumber, command.PageSize);
        }
        
        public async Task<IEnumerable<SelectListIngredientCommandResult>> GetSelectListAsync() {
			return await _context.Ingredient.AsNoTracking()
			    .OrderBy(x => x.Description)
			    .Select(IngredientSpecs.AsSelectListIngredientCommandResult)
			    .ToListAsync();
        }
    }
}
