using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Repositories;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Recipe;
using MBCTech.RecipeShopper.Dbo.Domain.Specs;
using MBCTech.RecipeShopper.Dbo.Infra.Data.Contexts;
using MBCTech.RecipeShopper.Shared.Infra.Data.Repositories;
using MBCTech.RecipeShopper.Shared.Infra.Data.Transactions;
using Dapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Tolitech.Modules.Shared.Domain.Commands;
using Tolitech.Modules.Shared.Domain.Entities;
using Tolitech.Modules.Shared.Notification;
using Tolitech.Modules.Shared.Infra.Data.Extensions;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Infra.Data.Repositories {
    
    
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
				string sql = GetSqlInsert(item, "Dbo", "Recipe", true, new List<string> { "Id" });
				var id = (await _uow.Connection.QueryAsync<System.Int32>(sql, item, _uow.Transaction)).Single();
				item.SetId(id);
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
				string sql = GetSqlUpdate(item, "Dbo", "Recipe", new List<string> { "Id" }, ignoreColumns: new List<string>() { "DataDeCadastro" });
			    await _uow.Connection.ExecuteAsync(sql, item, _uow.Transaction);
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
				 string sql = GetSqlDelete("Dbo", "Recipe", new List<string> { "Id" });
			    await _uow.Connection.ExecuteAsync(sql, new { id }, _uow.Transaction);
			}
			catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<RecipeCommandResult> GetByIdAsync(int id) {
			return await _context.Recipe.AsNoTracking()
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
			    .DynamicOrderBy(command.OrderBy)
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
