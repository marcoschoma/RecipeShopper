using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist {
    
    
    public class InsertShoplistCommand : InputCommand, ICommand {
        
        public virtual System.DateTime CreationDate {
            get;
            set;
        }
    }
}
