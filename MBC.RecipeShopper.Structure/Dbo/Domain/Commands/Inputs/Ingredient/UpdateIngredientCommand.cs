using System; 
using System.Collections.Generic; 
using System.Text;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient {
    
    
    public class UpdateIngredientCommand : InputCommand, ICommand {
        
        public virtual int Id {
            get;
            set;
        }
    }
}
