using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Threading.Tasks;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Repositories;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
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
    
    
    public class AmountTypeRepository : Repository, IAmountTypeRepository {
        
        private IUnitOfWork _uow;
        
        private DboDataContext _context;
        
        public AmountTypeRepository(IUnitOfWork uow, DboDataContext context) : 
                base(uow, context) {
			_uow = uow;
			_context = context;
        }
        
        public async Task<NotificationResult> InsertAsync(AmountTypeInfo item) {
			var result = new NotificationResult();
			try
			{
				string sql = GetSqlInsert(item, "Dbo", "AmountType", true, new List<string> { "Id" });
				var id = (await _uow.Connection.QueryAsync<System.Int32>(sql, item, _uow.Transaction)).Single();
				item.SetId(id);
			}
			catch(Exception ex)
			{
				result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<NotificationResult> UpdateAsync(AmountTypeInfo item) {
			var result = new NotificationResult();
			
			try
			{
				string sql = GetSqlUpdate(item, "Dbo", "AmountType", new List<string> { "Id" }, ignoreColumns: new List<string>() { "DataDeCadastro" });
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
				 string sql = GetSqlDelete("Dbo", "AmountType", new List<string> { "Id" });
			    await _uow.Connection.ExecuteAsync(sql, new { id }, _uow.Transaction);
			}
			catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<AmountTypeCommandResult> GetByIdAsync(int id) {
			return await _context.AmountType.AsNoTracking()
			    .Where(x => x.Id == id)
			    .Select(AmountTypeSpecs.AsAmountTypeCommandResult)
			    .SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<AmountTypeCommandResult>> GetAsync() {
			return await _context.AmountType.AsNoTracking()
			    .OrderBy(x => x.Description)
			    .Select(AmountTypeSpecs.AsAmountTypeCommandResult)
			    .ToListAsync();
        }
        
        public async Task<PaginatedList<PageAmountTypeCommandResult>> GetPageAsync(PageAmountTypeCommand command) {
			var source = _context.AmountType.AsNoTracking().AsExpandable();
			var outer = PredicateBuilder.New<AmountTypeInfo>(true);
			
			if (!string.IsNullOrEmpty(command.TextToSearch))
			{
			    var inner = PredicateBuilder.New<AmountTypeInfo>();
			    inner = inner.Start(AmountTypeSpecs.TextToSearch(command.TextToSearch));
			    outer = outer.And(inner);
			}
			
			var count = await source.Where(outer).CountAsync();
			var items = await source.Where(outer)
			    .DynamicOrderBy(command.OrderBy)
			    .Skip(command.SkipNumber)
			    .Take(command.PageSize)
			    .Select(AmountTypeSpecs.AsPageAmountTypeCommandResult)
			    .ToListAsync();
			
			return new PaginatedList<PageAmountTypeCommandResult>(items, count, command.PageNumber, command.PageSize);
        }
        
        public async Task<IEnumerable<SelectListAmountTypeCommandResult>> GetSelectListAsync() {
			return await _context.AmountType.AsNoTracking()
			    .OrderBy(x => x.Description)
			    .Select(AmountTypeSpecs.AsSelectListAmountTypeCommandResult)
			    .ToListAsync();
        }
    }
}
