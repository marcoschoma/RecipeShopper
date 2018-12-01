using MBC.RecipeShopper.Shared.Infra;
using MBCTech.RecipeShopper.Shared.Infra.Data.Transactions;
using System;
using System.Linq;

namespace MBCTech.RecipeShopper.Shared.Application
{
    /// <summary>
    /// Application service base.
    /// </summary>
    public abstract class ApplicationService
    {
        protected readonly IUnitOfWork _uow;
        private NotificationResult result;

        public ApplicationService(IUnitOfWork uow)
        {
            this._uow = uow;
            result = new NotificationResult();
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public NotificationResult Commit(NotificationResult result)
        {
            if (result.IsValid)
            {
                try
                {
                    _uow.Commit();
                }
                catch (Exception ex)
                {
                    _uow.Rollback();
                    result.AddError(ex);
                }
            }
            else
            {
                _uow.Rollback();
            }

            // Removing the exceptions objects before returning the result.
            result.Errors.ToList().ForEach(x => x.Exception = null);

            return result;
        }
    }
}