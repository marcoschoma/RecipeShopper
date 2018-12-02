using System;
using System.Collections.Generic;
using System.Text;

namespace MBC.RecipeShopper.Shared.Domain.Commands
{
    public abstract class PageCommand
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int SkipNumber { get; set; }
    }
}
