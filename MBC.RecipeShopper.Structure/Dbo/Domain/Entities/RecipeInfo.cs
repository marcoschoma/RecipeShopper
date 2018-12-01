using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Shared.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBCTech.RecipeShopper.Dbo.Domain.Scopes.Recipe;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Entities {
    
    
    public class RecipeInfo : EntityInfo {
        
        public RecipeInfo() {
        }
        
        public RecipeInfo(InsertRecipeCommand command) {
			Map(command);
			this.InsertOrUpdateScopeValidate();
        }
        
        public RecipeInfo(UpdateRecipeCommand command) {
			Map(command);
			this.InsertOrUpdateScopeValidate();
        }
        
        public System.Nullable<int> Id {
            get {
            }
            set {
            }
        }
        
        public string Name {
            get {
            }
            set {
            }
        }
        
        public string Steps {
            get {
            }
            set {
            }
        }
        
        public void SetId(int id) {
			if (!Id.HasValue) Id = id;
        }
    }
}
