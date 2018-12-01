using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Tolitech.Modules.Shared.Notification;


namespace MBCTech.RecipeShopper.Dbo.Domain.Scopes.RecipeIngredient {
    
    
    public static class RecipeIngredientScopes {
        
        public static void InsertOrUpdateScopeValidate(this RecipeIngredientInfo item) {
			new NotificationContract<RecipeIngredientInfo>(item)
;
        }
    }
}
