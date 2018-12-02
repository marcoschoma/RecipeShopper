using MBC.RecipeShopper.Shared.Domain.Entities;
using MBC.RecipeShopper.Shared.Infra.Data.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra.Data.Repositories
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

        public string GetSqlInsert(EntityInfo item, string v1, string table, bool v3, List<string> keys)
        {
            var insertSql = $"insert into {table} values ";
            
            throw new NotImplementedException();
        }
        public string GetSqlUpdate(EntityInfo item, string v1, string v2, List<string> list, List<string> ignoreColumns)
        {
            throw new NotImplementedException();
        }
        public string GetSqlDelete(string v1, string v2, List<string> list)
        {
            throw new NotImplementedException();
        }
    }
}
