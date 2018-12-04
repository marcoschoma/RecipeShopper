using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Domain.Scopes.RecipeIngredient;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Entities {
    
    
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
            get;
            private set;
        }

        public System.Nullable<int> RecipeId
        {
            get;
            private set;
        }

        public System.Nullable<int> IngredientId {
            get;
            private set;
        }
        
        public System.Nullable<int> AmountTypeId {
            get;
            set;
        }
        
        public System.Nullable<decimal> Amount {
            get;
            set;
        }
        
        public virtual IngredientInfo Ingredient {
            get;
            set;
        }
        
        public virtual AmountTypeInfo AmountType {
            get;
            set;
        }

        public virtual RecipeInfo Recipe
        {
            get;
            set;
        }

        public void SetId(int id) {
			if (!Id.HasValue) Id = id;
        }
    }
}
