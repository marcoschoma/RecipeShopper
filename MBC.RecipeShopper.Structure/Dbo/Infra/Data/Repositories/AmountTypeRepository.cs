using Dapper;
using LinqKit;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
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

    public class AmountTypeRepository : Repository, IAmountTypeRepository
    {

        private IUnitOfWork _uow;

        private DboDataContext _context;

        public AmountTypeRepository(IUnitOfWork uow, DboDataContext context) :
                base(uow, context)
        {
            _uow = uow;
            _context = context;
        }

        public async Task<NotificationResult> InsertAsync(AmountTypeInfo item)
        {
            var result = new NotificationResult();
            try
            {
                await _context.AddAsync(item);
                item.SetId(_context.SaveChanges());
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }


        public async Task<NotificationResult> UpdateAsync(AmountTypeInfo item)
        {
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

        public async Task<NotificationResult> DeleteByIdAsync(int id)
        {
            var result = new NotificationResult();
            try
            {
                await _uow.Connection.ExecuteAsync("delete from AmountType where Id = @id", new { id }, _uow.Transaction);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public async Task<AmountTypeCommandResult> GetByIdAsync(int id)
        {
            return await _context.AmountType.AsNoTracking()
                .Where(x => x.Id == id)
                .Select(AmountTypeSpecs.AsAmountTypeCommandResult)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<AmountTypeCommandResult>> GetAsync()
        {
            return await _context.AmountType.AsNoTracking()
                .OrderBy(x => x.Description)
                .Select(AmountTypeSpecs.AsAmountTypeCommandResult)
                .ToListAsync();
        }

        public async Task<PaginatedList<PageAmountTypeCommandResult>> GetPageAsync(PageAmountTypeCommand command)
        {
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
                .Skip(command.SkipNumber)
                .Take(command.PageSize)
                .Select(AmountTypeSpecs.AsPageAmountTypeCommandResult)
                .ToListAsync();

            return new PaginatedList<PageAmountTypeCommandResult>(items, count, command.PageNumber, command.PageSize);
        }

        public async Task<IEnumerable<SelectListAmountTypeCommandResult>> GetSelectListAsync()
        {
            return await _context.AmountType.AsNoTracking()
                .OrderBy(x => x.Description)
                .Select(AmountTypeSpecs.AsSelectListAmountTypeCommandResult)
                .ToListAsync();
        }
    }
}
