using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient {
    
    
    public class SelectListShoplistIngredientCommandResult : ICommandResult {
        
        public System.Nullable<int> Id {
            get;
            set;
        }
        
        public virtual SelectListShoplistCommandResult Shoplist {
            get;
            set;
        }
        
        public virtual SelectListIngredientCommandResult Ingredient {
            get;
            set;
        }
        
        public virtual SelectListAmountTypeCommandResult AmountType {
            get;
            set;
        }
    }
}
