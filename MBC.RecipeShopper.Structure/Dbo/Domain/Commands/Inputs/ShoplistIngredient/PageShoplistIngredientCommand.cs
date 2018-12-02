using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient {
    
    
    public class PageShoplistIngredientCommand : PageCommand, ICommand {
        
        public PageShoplistIngredientCommand() {
			ShoplistId = new List<System.Int32>();
			IngredientId = new List<System.Int32>();
			AmountTypeId = new List<System.Int32>();
        }
        
        public virtual String TextToSearch {
            get;
            set;
        }
        
        public virtual ICollection<System.Int32> ShoplistId {
            get;
            set;
        }
        
        public virtual ICollection<System.Int32> IngredientId {
            get;
            set;
        }
        
        public virtual ICollection<System.Int32> AmountTypeId {
            get;
            set;
        }
    }
}
