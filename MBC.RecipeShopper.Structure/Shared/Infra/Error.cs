using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Infra
{
    public class Error
    {
        private Exception ex;

        public Error(Exception ex)
        {
            this.ex = ex;
        }

        public Exception Exception { get; set; }
    }
}
