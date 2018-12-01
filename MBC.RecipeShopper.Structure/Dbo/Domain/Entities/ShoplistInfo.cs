using System; 
using System.Collections.Generic; 
using System.Text; 
using MBCTech.RecipeShopper.Shared.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBCTech.RecipeShopper.Dbo.Domain.Scopes.Shoplist;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Entities {
    
    
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
        
        public System.Nullable<int> Id {
            get {
            }
            set {
            }
        }
        
        public System.DateTime CreationDate {
            get {
            }
            set {
            }
        }
        
        public virtual ICollection<ShoplistIngredientInfo> ShoplistsIngredients {
            get {
            }
            set {
            }
        }
        
        private void InitCollections() {
			ShoplistsIngredients = new List<ShoplistIngredientInfo>();
        }
        
        public void SetId(int id) {
			if (!Id.HasValue) Id = id;
        }
    }
}
