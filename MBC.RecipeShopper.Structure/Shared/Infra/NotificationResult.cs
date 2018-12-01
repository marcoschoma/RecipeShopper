using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra
{
    public class NotificationResult
    {
        public bool IsValid { get; set; }
        public IList<Error> Errors { get; set; }

        public void AddError(Exception ex)
        {
            if (Errors == null)
                Errors = new List<Error>();
            Errors.Add(new Error(ex));
        }
    }
}
