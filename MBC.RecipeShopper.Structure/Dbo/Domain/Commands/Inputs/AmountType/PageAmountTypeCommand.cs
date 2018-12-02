using System; 
using System.Collections.Generic; 
using System.Text;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType {
    
    
    public class PageAmountTypeCommand : PageCommand, ICommand {
        
        public PageAmountTypeCommand() {
        }
        
        public virtual String TextToSearch {
            get;
            set;
        }
    }
}
