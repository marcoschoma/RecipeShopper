using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.ShoplistIngredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient {
    
    
    public class IngredientCommandResult : ICommandResult {
        
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
