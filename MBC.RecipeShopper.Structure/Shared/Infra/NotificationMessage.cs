using System;
namespace MBC.RecipeShopper.Shared.Infra
{
    public class NotificationMessage
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }

        public NotificationMessage(string message)
        {
            Key = Guid.NewGuid().ToString();
            Message = message;
            Type = "Information";
        }
    }
}
