using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist {
    
    
    public class ShoplistCommandResult : ICommandResult {
        
        public System.Nullable<int> Id {
            get;
            set;
        }
        
        public System.DateTime CreationDate {
            get;
            set;
        }
        
        public virtual ICollection<ShoplistIngredientCommandResult> ShoplistIngredients {
            get;
            set;
        }
    }
}
