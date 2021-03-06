using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Scopes.Shoplist;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Entities {
    
    
    public class ShoplistInfo : EntityInfo {

        public ShoplistInfo() {
        }
        
        public ShoplistInfo(InsertShoplistCommand command) {
			Map(command);
			InitCollections();
			this.InsertOrUpdateScopeValidate();
        }
        
        public ShoplistInfo(UpdateShoplistCommand command) {
			Map(command);
			InitCollections();
			this.InsertOrUpdateScopeValidate();
        }

        public ShoplistInfo(InsertShoplistWithIngredientsCommand command)
        {
            Map(command);
            InitCollections();
            foreach (var shoplistIngredientCommand in command.ShoplistsIngredients)
            {
                ShoplistsIngredients.Add(new ShoplistIngredientInfo(shoplistIngredientCommand));
            }
            this.InsertOrUpdateScopeValidate();
        }

        public System.Nullable<int> Id {
            get;
            private set;
        }
        
        public System.DateTime CreationDate {
            get;
            private set;
        }
        
        public virtual ICollection<ShoplistIngredientInfo> ShoplistsIngredients {
            get;
            set;
        }
        
        private void InitCollections() {
            ShoplistsIngredients = new List<ShoplistIngredientInfo>();
        }
        
        public void SetId(int id) {
			if (!Id.HasValue) Id = id;
        }
    }
}
