using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra
{
    public class NotifiableEntityInfo
    {
        private NotificationResult NotificationResult;

        public NotificationResult GetNotificationResult()
        {
            return NotificationResult;
        }

        internal void SetNotificationResult(bool isValid)
        {
            NotificationResult = new NotificationResult();
            NotificationResult.IsValid = isValid;
        }
    }
}
