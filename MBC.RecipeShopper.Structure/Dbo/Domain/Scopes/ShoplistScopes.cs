using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Shared.Infra;

namespace MBC.RecipeShopper.Dbo.Domain.Scopes.Shoplist
{

    public static class ShoplistScopes {
        
        public static void InsertOrUpdateScopeValidate(this ShoplistInfo item) {
			new NotificationContract<ShoplistInfo>(item);
        }
    }
}
