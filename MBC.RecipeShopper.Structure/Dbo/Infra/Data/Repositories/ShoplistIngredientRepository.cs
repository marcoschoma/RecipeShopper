using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
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
    
    
    public class ShoplistIngredientRepository : Repository, IShoplistIngredientRepository {
        
        private IUnitOfWork _uow;
        
        private DboDataContext _context;
        
        public ShoplistIngredientRepository(IUnitOfWork uow, DboDataContext context) : 
                base(uow, context) {
			_uow = uow;
			_context = context;
        }
        
        public async Task<NotificationResult> InsertAsync(ShoplistIngredientInfo item) {
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
        
        public async Task<NotificationResult> UpdateAsync(ShoplistIngredientInfo item) {
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
                await _uow.Connection.ExecuteAsync("delete from ShoplistIngredient where Id = @id", new { id }, _uow.Transaction);
            }
			catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<ShoplistIngredientCommandResult> GetByIdAsync(int id) {
			return await _context.ShoplistIngredient.AsNoTracking()
			    .Where(x => x.Id == id)
			    .Select(ShoplistIngredientSpecs.AsShoplistIngredientCommandResult)
			    .SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<ShoplistIngredientCommandResult>> GetAsync() {
			return await _context.ShoplistIngredient.AsNoTracking()
			    .Include(x => x.Shoplist)
			    .Include(x => x.Ingredient)
			    .Include(x => x.AmountType)
			    .Select(ShoplistIngredientSpecs.AsShoplistIngredientCommandResult)
			    .ToListAsync();
        }
        
        public async Task<PaginatedList<PageShoplistIngredientCommandResult>> GetPageAsync(PageShoplistIngredientCommand command) {
			var source = _context.ShoplistIngredient.AsNoTracking().AsExpandable();
			var outer = PredicateBuilder.New<ShoplistIngredientInfo>(true);
			
			if (command.ShoplistId.Any())
			    outer = outer.Start(x => command.ShoplistId.Contains(x.ShoplistId.Value));
			
			if (command.IngredientId.Any())
			    outer = outer.Start(x => command.IngredientId.Contains(x.IngredientId.Value));
			
			if (command.AmountTypeId.Any())
			    outer = outer.Start(x => command.AmountTypeId.Contains(x.AmountTypeId.Value));
			
			if (!string.IsNullOrEmpty(command.TextToSearch))
			{
			    var inner = PredicateBuilder.New<ShoplistIngredientInfo>();
			    inner = inner.Start(ShoplistIngredientSpecs.TextToSearch(command.TextToSearch));
			    outer = outer.And(inner);
			}
			
			var count = await source.Where(outer).CountAsync();
			var items = await source.Where(outer)
			    .Skip(command.SkipNumber)
			    .Take(command.PageSize)
			    .Include(x => x.Shoplist)
			    .Include(x => x.Ingredient)
			    .Include(x => x.AmountType)
			    .Select(ShoplistIngredientSpecs.AsPageShoplistIngredientCommandResult)
			    .ToListAsync();
			
			return new PaginatedList<PageShoplistIngredientCommandResult>(items, count, command.PageNumber, command.PageSize);
        }
        
        public async Task<IEnumerable<SelectListShoplistIngredientCommandResult>> GetSelectListAsync() {
			return await _context.ShoplistIngredient.AsNoTracking()
			    .Select(ShoplistIngredientSpecs.AsSelectListShoplistIngredientCommandResult)
			    .ToListAsync();
        }
    }
}
