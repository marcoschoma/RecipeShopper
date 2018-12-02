using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Shared.Infra;


namespace MBC.RecipeShopper.Dbo.Domain.Scopes.AmountType {
    
    
    public static class AmountTypeScopes {
        
        public static void InsertOrUpdateScopeValidate(this AmountTypeInfo item) {
			new NotificationContract<AmountTypeInfo>(item)
			.HasMaxLenght(item.Description, 100, nameof(item.Description), Resources.AmountType.Description_FieldName)
;
        }
    }
}
