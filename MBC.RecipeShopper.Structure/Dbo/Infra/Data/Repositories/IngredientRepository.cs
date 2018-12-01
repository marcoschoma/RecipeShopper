using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Repositories;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
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
				string sql = GetSqlInsert(item, "Dbo", "Ingredient", true, new List<string> { "Id" });
				var id = (await _uow.Connection.QueryAsync<System.Int32>(sql, item, _uow.Transaction)).Single();
				item.SetId(id);
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
				string sql = GetSqlUpdate(item, "Dbo", "Ingredient", new List<string> { "Id" }, ignoreColumns: new List<string>() { "DataDeCadastro" });
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
				 string sql = GetSqlDelete("Dbo", "Ingredient", new List<string> { "Id" });
			    await _uow.Connection.ExecuteAsync(sql, new { id }, _uow.Transaction);
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
			    .DynamicOrderBy(command.OrderBy)
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
