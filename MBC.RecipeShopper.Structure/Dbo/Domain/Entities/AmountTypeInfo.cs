using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.AmountType;
using MBC.RecipeShopper.Dbo.Domain.Scopes.AmountType;
using MBC.RecipeShopper.Dbo;

namespace MBC.RecipeShopper.Dbo.Domain.Entities {
    
    
    public class AmountTypeInfo : EntityInfo {
        
        public AmountTypeInfo() {
        }
        
        public AmountTypeInfo(InsertAmountTypeCommand command) {
			Map(command);
			InitCollections();
			this.InsertOrUpdateScopeValidate();
        }
        
        public AmountTypeInfo(UpdateAmountTypeCommand command) {
			Map(command);
			InitCollections();
			this.InsertOrUpdateScopeValidate();
        }
        
        public System.Nullable<int> Id {
            get;
            private set;
        }
        
        public string Description {
            get;
            private set;
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
