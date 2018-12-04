using System; 
using System.Collections.Generic; 
using System.Text;
using MBC.RecipeShopper.Shared.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Scopes.Recipe;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Entities {
    
    
    public class RecipeInfo : EntityInfo {
        
        public RecipeInfo() {
        }
        
        public RecipeInfo(InsertRecipeCommand command) {
			Map(command);
            InitCollections();
            this.InsertOrUpdateScopeValidate();
        }
        
        public RecipeInfo(UpdateRecipeCommand command) {
			Map(command);
            InitCollections();
            this.InsertOrUpdateScopeValidate();
        }
        
        public System.Nullable<int> Id {
            get;
            private set;
        }
        
        public string Name {
            get;
            private set;
        }
        
        public string Steps {
            get;
            private set;
        }
        
        public void SetId(int id) {
			if (!Id.HasValue) Id = id;
        }

        private void InitCollections()
        {
            RecipeIngredients = new List<RecipeIngredientInfo>();
        }

        public virtual ICollection<RecipeIngredientInfo> RecipeIngredients { get; private set; }


    }
}
