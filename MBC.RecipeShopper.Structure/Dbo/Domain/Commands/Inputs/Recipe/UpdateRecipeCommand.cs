using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe {
    
    public class UpdateRecipeCommand : InputCommand, ICommand {
        
        public virtual string Name {
            get;
            set;
        }

        public virtual string Steps
        {
            get;
            set;
        }
        public int Id { get; set; }
    }
}
