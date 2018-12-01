using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Tolitech.Modules.Shared.Notification;


namespace MBCTech.RecipeShopper.Dbo.Domain.Scopes.Shoplist {
    
    
    public static class ShoplistScopes {
        
        public static void InsertOrUpdateScopeValidate(this ShoplistInfo item) {
			new NotificationContract<ShoplistInfo>(item)
;
        }
    }
}
