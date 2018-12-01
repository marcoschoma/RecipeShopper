using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Tolitech.Modules.Shared.Notification;


namespace MBCTech.RecipeShopper.Dbo.Domain.Scopes.Ingredient {
    
    
    public static class IngredientScopes {
        
        public static void InsertOrUpdateScopeValidate(this IngredientInfo item) {
			new NotificationContract<IngredientInfo>(item)
			.HasMaxLenght(item.Description, 100, nameof(item.Description), Resources.Ingredient.Description_FieldName)
;
        }
    }
}
