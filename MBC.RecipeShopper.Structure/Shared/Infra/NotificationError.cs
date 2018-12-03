using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra
{
    public class NotificationError
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public NotificationError(Exception ex)
        {
            Key = Guid.NewGuid().ToString();

            this.Exception = ex;
            if (ex != null)
                this.Message = ex.Message;

        }

    }
}
