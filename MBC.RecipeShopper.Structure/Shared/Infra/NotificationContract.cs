using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra
{
    public class NotificationContract<TEntity> where TEntity : NotifiableEntityInfo
    {
        private TEntity item;

        public NotificationContract(TEntity item)
        {
            this.item = item;
            item.SetNotificationResult(true);
        }

        public NotificationContract<TEntity> HasMaxLenght(string fieldValue, int maxLength, string fieldName, string errorMessage)
        {
            if (!string.IsNullOrEmpty(fieldName) && maxLength > 0 && fieldValue.Length > maxLength)
            {
                item.SetNotificationResult(false);
                item.GetNotificationResult().AddError(new Exception(errorMessage));
            }
            return this;
        }
    }
}
