using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType {
    
    
    public class InsertAmountTypeCommand : InputCommand, ICommand {
        
        public virtual string Description {
            get;
            set;
        }
    }
}
