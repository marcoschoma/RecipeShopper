using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient {
    
    
    public class ShoplistIngredientCommandResult : ICommandResult {
        
        public System.Nullable<int> Id {
            get;
            set;
        }
        
        public System.Nullable<int> ShoplistId {
            get;
            set;
        }
        
        public System.Nullable<int> IngredientId {
            get;
            set;
        }
        
        public System.Nullable<int> AmountTypeId {
            get;
            set;
        }
        
        public System.Nullable<decimal> Amount {
            get;
            set;
        }
        
        public virtual ShoplistCommandResult Shoplist {
            get;
            set;
        }
        
        public virtual IngredientCommandResult Ingredient {
            get;
            set;
        }
        
        public virtual AmountTypeCommandResult AmountType
        {
            get;
            set;
        }
    }
}
