using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using Tolitech.Modules.Shared.Notification;


namespace MBCTech.RecipeShopper.Dbo.Domain.Scopes.Recipe {
    
    
    public static class RecipeScopes {
        
        public static void InsertOrUpdateScopeValidate(this RecipeInfo item) {
			new NotificationContract<RecipeInfo>(item)
			.HasMaxLenght(item.Name, 100, nameof(item.Name), Resources.Recipe.Name_FieldName)
			.HasMaxLenght(item.Steps, -1, nameof(item.Steps), Resources.Recipe.Steps_FieldName)
;
        }
    }
}
