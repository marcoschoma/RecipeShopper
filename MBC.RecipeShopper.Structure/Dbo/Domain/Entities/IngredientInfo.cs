using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Scopes.Ingredient;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Entities {
    
    
    public class IngredientInfo : EntityInfo {
        
        public IngredientInfo() {
        }
        
        public IngredientInfo(InsertIngredientCommand command) {
			Map(command);
			InitCollections();
			this.InsertOrUpdateScopeValidate();
        }
        
        public IngredientInfo(UpdateIngredientCommand command) {
			Map(command);
            this.Id = command.Id;
			InitCollections();
			this.InsertOrUpdateScopeValidate();
        }
        
        public System.Nullable<int> Id {
            get;
            set;
        }
        
        public string Description {
            get;
            set;
        }
        
        public virtual ICollection<RecipeIngredientInfo> RecipesIngredients {
            get;
            set;
        }
        
        public virtual ICollection<ShoplistIngredientInfo> ShoplistsIngredients {
            get;
            set;
        }
        
        private void InitCollections() {
			RecipesIngredients = new List<RecipeIngredientInfo>();
			ShoplistsIngredients = new List<ShoplistIngredientInfo>();
        }
        
        public void SetId(int id) {
			if (!Id.HasValue) Id = id;
        }
    }
}
