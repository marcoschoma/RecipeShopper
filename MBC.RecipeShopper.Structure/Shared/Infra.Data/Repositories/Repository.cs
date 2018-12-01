using MBCTech.RecipeShopper.Shared.Infra.Data.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBCTech.RecipeShopper.Shared.Infra.Data.Repositories
{
    public abstract class Repository
    {
        private readonly IUnitOfWork _uow;
        private readonly DbContext _context;

        public Repository(IUnitOfWork uow, DbContext context)
        {
            this._uow = uow;
            this._context = context;

            Configure();
        }

        public void UseTransaction()
        {
            _context.Database.UseTransaction(_uow.Transaction);
        }

        private void Configure()
        {
            //base.SetDatabase(_uow.DatabaseEnum);
        }
    }
}
