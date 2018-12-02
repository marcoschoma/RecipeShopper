using System; 
using System.Collections.Generic; 
using System.Text;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient {
    
    
    public class PageIngredientCommand : PageCommand, ICommand {
        
        public PageIngredientCommand() {
        }
        
        public virtual String TextToSearch {
            get;
            set;
        }
    }
}
