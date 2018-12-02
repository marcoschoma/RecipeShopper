using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Results.Recipe {
    
    
    public class PageRecipeCommandResult : ICommandResult {
        
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
    }
}
