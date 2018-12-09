using Dapper;
using LinqKit;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Repositories;
using MBC.RecipeShopper.Dbo.Domain.Specs;
using MBC.RecipeShopper.Dbo.Infra.Data.Contexts;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Shared.Infra.Data.Repositories;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBC.RecipeShopper.Dbo.Infra.Data.Repositories
{

    public class ShoplistRepository : Repository, IShoplistRepository {
        
        private IUnitOfWork _uow;
        
        private DboDataContext _context;
        
        public ShoplistRepository(IUnitOfWork uow, DboDataContext context) : 
                base(uow, context) {
			_uow = uow;
			_context = context;
        }
        
        public async Task<NotificationResult> InsertAsync(ShoplistInfo item) {
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
        
        public async Task<NotificationResult> UpdateAsync(ShoplistInfo item) {
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
                await _uow.Connection.ExecuteAsync("delete from Shoplist where Id = @id", new { id }, _uow.Transaction);
            }
            catch (Exception ex)
			{
			    result.AddError(ex);
			}
			
			return result;
        }
        
        public async Task<ShoplistCommandResult> GetByIdAsync(int id) {
			return await _context.Shoplist.AsNoTracking()
                .Include(s => s.ShoplistsIngredients)
                .Where(x => x.Id == id)
			    .Select(ShoplistSpecs.AsShoplistCommandResult)
			    .SingleOrDefaultAsync();
        }
        
        public async Task<IEnumerable<ShoplistCommandResult>> GetAsync() {
			return await _context.Shoplist
                .Include(s => s.ShoplistsIngredients)
                .AsNoTracking()
                .OrderByDescending(si => si.Id)
			    .Select(ShoplistSpecs.AsShoplistCommandResult)
			    .ToListAsync();
        }
        
        public async Task<PaginatedList<PageShoplistCommandResult>> GetPageAsync(PageShoplistCommand command) {
			var source = _context.Shoplist.AsNoTracking().AsExpandable();
			var outer = PredicateBuilder.New<ShoplistInfo>(true);
			
			if (!string.IsNullOrEmpty(command.TextToSearch))
			{
			    var inner = PredicateBuilder.New<ShoplistInfo>();
			    inner = inner.Start(ShoplistSpecs.TextToSearch(command.TextToSearch));
			    outer = outer.And(inner);
			}
			
			var count = await source.Where(outer).CountAsync();
			var items = await source.Where(outer)
			    .Skip(command.SkipNumber)
			    .Take(command.PageSize)
			    .Select(ShoplistSpecs.AsPageShoplistCommandResult)
			    .ToListAsync();
			
			return new PaginatedList<PageShoplistCommandResult>(items, count, command.PageNumber, command.PageSize);
        }
        
        public async Task<IEnumerable<SelectListShoplistCommandResult>> GetSelectListAsync() {
			return await _context.Shoplist.AsNoTracking()
			    .Select(ShoplistSpecs.AsSelectListShoplistCommandResult)
			    .ToListAsync();
        }
    }
}
