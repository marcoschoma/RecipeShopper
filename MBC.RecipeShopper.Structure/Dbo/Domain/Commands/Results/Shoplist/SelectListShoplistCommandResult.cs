using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist {
    
    
    public class SelectListShoplistCommandResult : ICommandResult {
        
        public System.Nullable<int> Id {
            get;
            set;
        }
    }
}
