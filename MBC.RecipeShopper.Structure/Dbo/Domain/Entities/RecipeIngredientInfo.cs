using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Shared.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBCTech.RecipeShopper.Dbo.Domain.Scopes.RecipeIngredient;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Entities {
    
    
    public class RecipeIngredientInfo : EntityInfo {
        
        public RecipeIngredientInfo() {
        }
        
        public RecipeIngredientInfo(InsertRecipeIngredientCommand command) {
			Map(command);
			this.InsertOrUpdateScopeValidate();
        }
        
        public RecipeIngredientInfo(UpdateRecipeIngredientCommand command) {
			Map(command);
			this.InsertOrUpdateScopeValidate();
        }
        
        public System.Nullable<int> Id {
            get {
            }
            set {
            }
        }
        
        public System.Nullable<int> IngredientId {
            get {
            }
            set {
            }
        }
        
        public System.Nullable<int> AmountTypeId {
            get {
            }
            set {
            }
        }
        
        public System.Nullable<decimal> Amount {
            get {
            }
            set {
            }
        }
        
        public virtual IngredientInfo Ingredient {
            get {
            }
            set {
            }
        }
        
        public virtual AmountTypeInfo AmountType {
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
