using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Linq.Expressions;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Specs {
    
    
    public class ShoplistSpecs {
        

        public static readonly Expression<Func<ShoplistInfo, SelectListShoplistCommandResult>> AsSelectListShoplistCommandResult = x => new SelectListShoplistCommandResult
				{
					Id = x.Id,
				}
;

        public static readonly Expression<Func<ShoplistInfo, PageShoplistCommandResult>> AsPageShoplistCommandResult = x => new PageShoplistCommandResult
				{
					Id = x.Id,
				}
;

        public static readonly Expression<Func<ShoplistInfo, ShoplistCommandResult>> AsShoplistCommandResult = x => new ShoplistCommandResult
				{
					Id = x.Id,
				}
;
public static Expression<Func<ShoplistInfo, bool>> TextToSearch(string textToSearch)
            {
                return x => (true); }
    }
}
