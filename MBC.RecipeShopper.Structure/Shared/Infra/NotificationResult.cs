using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra
{
    public class NotificationResult
    {
        public NotificationResult()
        {
            Errors = new List<Error>();
            Messages = new List<string>();
            IsValid = true;
        }
        public bool IsValid { get; set; }
        public IList<Error> Errors { get; set; }
        public IList<string> Messages { get; set; }
        public int? Data { get; set; }

        public void AddError(Exception ex)
        {
            Errors.Add(new Error(ex));
            IsValid = false;

        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public void AddErrorOnTop(string message)
        {
            Errors.Insert(0, new Error(new Exception(message)));
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
