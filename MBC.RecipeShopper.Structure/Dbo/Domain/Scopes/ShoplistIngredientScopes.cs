using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Tolitech.Modules.Shared.Notification;


namespace MBCTech.RecipeShopper.Dbo.Domain.Scopes.ShoplistIngredient {
    
    
    public static class ShoplistIngredientScopes {
        
        public static void InsertOrUpdateScopeValidate(this ShoplistIngredientInfo item) {
			new NotificationContract<ShoplistIngredientInfo>(item)
;
        }
    }
}
