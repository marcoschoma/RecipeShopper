using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Shared.Infra;


namespace MBC.RecipeShopper.Dbo.Domain.Scopes.RecipeIngredient {
    
    
    public static class RecipeIngredientScopes {
        
        public static void InsertOrUpdateScopeValidate(this RecipeIngredientInfo item) {
			new NotificationContract<RecipeIngredientInfo>(item)
;
        }
    }
}
