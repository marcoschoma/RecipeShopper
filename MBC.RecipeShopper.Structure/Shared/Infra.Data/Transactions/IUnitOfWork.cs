using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MBC.RecipeShopper.Shared.Infra.Data.Transactions
{
    public interface IUnitOfWork
    {
        DbConnection Connection { get; }

        DbTransaction Transaction { get; }

        //DatabaseEnum DatabaseEnum { get; set; }

        void AddContext(DbContext context);

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
