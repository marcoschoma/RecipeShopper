using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist {
    
    
    public class PageShoplistCommand : PageCommand, ICommand {
        
        public PageShoplistCommand() {
        }
        
        public virtual String TextToSearch {
            get;
            set;
        }
    }
}
