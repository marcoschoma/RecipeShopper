using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.RecipeIngredient;

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.Recipe {
    
    
    public class RecipeCommandResult : ICommandResult {
        
        public System.Nullable<int> Id {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }
        
        public string Steps {
            get;
            set; 
        }

        public ICollection<RecipeIngredientCommandResult> RecipeIngredients { get; set; }

    }
}
