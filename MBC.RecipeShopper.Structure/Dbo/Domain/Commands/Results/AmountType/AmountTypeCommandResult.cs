using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType {
    
    
    public class AmountTypeCommandResult : ICommandResult {
        
        public System.Nullable<int> Id {
            get;
            set;
        }
        
        public string Description {
            get;
            set;
        }
        
        public virtual ICollection<RecipeIngredientCommandResult> RecipeIngredients {
            get;
            set;
        }
        
        public virtual ICollection<ShoplistIngredientCommandResult> ShoplistIngredients {
            get;
            set;
        }
    }
}
