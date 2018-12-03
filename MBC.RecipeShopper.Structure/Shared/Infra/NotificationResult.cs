using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra
{
    public class NotificationResult
    {
        public bool IsValid { get; set; }
        public IList<NotificationError> Errors { get; set; }
        public IList<NotificationMessage> Messages { get; set; }
        public object Data { get; set; }

        public NotificationResult()
        {
            Errors = new List<NotificationError>();
            Messages = new List<NotificationMessage>();
            IsValid = true;
        }

        public void AddError(Exception ex)
        {
            Errors.Add(new NotificationError(ex));
            IsValid = false;

        }

        public void AddMessage(string message)
        {
            Messages.Add(new NotificationMessage(message));
        }

        public void AddErrorOnTop(string message)
        {
            Errors.Insert(0, new NotificationError(new Exception(message)));
            IsValid = false;
        }

        public void Add(NotificationResult notificationResult)
        {
            if(notificationResult != null)
            {
                if (notificationResult.Messages != null && notificationResult.Messages.Count > 0)
                    foreach (var message in notificationResult.Messages)
                        Messages.Add(message);
                if (notificationResult.Errors != null && notificationResult.Errors.Count > 0)
                    foreach (var error in notificationResult.Errors)
                        Errors.Add(error);
                IsValid = IsValid && notificationResult.IsValid;
            }
        }
    }
}
