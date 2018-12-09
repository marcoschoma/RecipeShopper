using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe {
    
    
    public class InsertRecipeCommand : InputCommand, ICommand {
        
        public virtual string Name {
            get;
            set;
        }
        
        public virtual string Steps {
            get;
            set;
        }

        public virtual ICollection<InsertRecipeIngredientCommand> RecipeIngredients { get; set; }

    }
}
