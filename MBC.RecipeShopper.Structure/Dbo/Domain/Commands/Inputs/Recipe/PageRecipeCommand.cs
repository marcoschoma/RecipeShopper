using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe {
    
    
    public class PageRecipeCommand : PageCommand, ICommand {
        
        public PageRecipeCommand() {
        }
        
        public virtual String TextToSearch {
            get;
            set;
        }
    }
}
