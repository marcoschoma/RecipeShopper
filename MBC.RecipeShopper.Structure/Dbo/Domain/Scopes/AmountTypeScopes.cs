using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Tolitech.Modules.Shared.Notification;


namespace MBCTech.RecipeShopper.Dbo.Domain.Scopes.AmountType {
    
    
    public static class AmountTypeScopes {
        
        public static void InsertOrUpdateScopeValidate(this AmountTypeInfo item) {
			new NotificationContract<AmountTypeInfo>(item)
			.HasMaxLenght(item.Description, 100, nameof(item.Description), Resources.AmountType.Description_FieldName)
;
        }
    }
}
