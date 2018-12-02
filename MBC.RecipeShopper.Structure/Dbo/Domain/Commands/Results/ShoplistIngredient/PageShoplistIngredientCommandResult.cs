using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Shared.Domain.Commands;

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient {
    
    
    public class PageShoplistIngredientCommandResult : ICommandResult {
        
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
