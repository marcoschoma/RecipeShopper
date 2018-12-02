using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;
using MBC.RecipeShopper.Dbo.Domain.Scopes.ShoplistIngredient;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Entities {
    
    
    public class ShoplistIngredientInfo : EntityInfo {
        
        public ShoplistIngredientInfo() {
        }
        
        public ShoplistIngredientInfo(InsertShoplistIngredientCommand command) {
			Map(command);
			this.InsertOrUpdateScopeValidate();
        }
        
        public ShoplistIngredientInfo(UpdateShoplistIngredientCommand command) {
			Map(command);
			this.InsertOrUpdateScopeValidate();
        }
        
        public System.Nullable<int> Id {
            get;
            set;
        }
        
        public System.Nullable<int> ShoplistId {
            get;
            set;
        }
        
        public System.Nullable<int> IngredientId {
            get;
            set;
        }
        
        public System.Nullable<int> AmountTypeId {
            get;
            set;
        }
        
        public System.Nullable<decimal> Amount {
            get;
            set;
        }
        
        public virtual ShoplistInfo Shoplist {
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
        
        public void SetId(int id) {
			if (!Id.HasValue) Id = id;
        }
    }
}
