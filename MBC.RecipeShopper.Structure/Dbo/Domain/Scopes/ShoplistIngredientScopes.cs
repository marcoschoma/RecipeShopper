using System; 
using System.Collections.Generic; 
using System.Text;
using MBC.RecipeShopper.Shared.Infra;
using MBC.RecipeShopper.Dbo.Domain.Entities;

namespace MBC.RecipeShopper.Dbo.Domain.Scopes.ShoplistIngredient {
    
    
    public static class ShoplistIngredientScopes {
        
        public static void InsertOrUpdateScopeValidate(this ShoplistIngredientInfo item) {
			new NotificationContract<ShoplistIngredientInfo>(item);
        }
    }
}
