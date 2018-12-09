using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Shoplist;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;

namespace MBC.RecipeShopper.Dbo.Domain.Specs
{


    public class ShoplistSpecs
    {


        public static readonly Expression<Func<ShoplistInfo, SelectListShoplistCommandResult>> AsSelectListShoplistCommandResult = x => new SelectListShoplistCommandResult
        {
            Id = x.Id,
        };

        public static readonly Expression<Func<ShoplistInfo, PageShoplistCommandResult>> AsPageShoplistCommandResult = x => new PageShoplistCommandResult
        {
            Id = x.Id,
            CreationDate = x.CreationDate,
        };

        public static readonly Expression<Func<ShoplistInfo, ShoplistCommandResult>> AsShoplistCommandResult = x => new ShoplistCommandResult
        {
            Id = x.Id,
            CreationDate = x.CreationDate,
            ShoplistIngredients = x.ShoplistsIngredients.Select(si => new Commands.Results.ShoplistIngredient.ShoplistIngredientCommandResult()
            {
                Amount = si.Amount,
                Ingredient = si.Ingredient == null ? null : new IngredientCommandResult
                {
                    Description = si.Ingredient.Description
                },
                AmountType = si.AmountType == null ? null : new AmountTypeCommandResult
                {
                    Description = si.AmountType.Description
                }
            }).ToList()
        };

        public static Expression<Func<ShoplistInfo, bool>> TextToSearch(string textToSearch)
        {
            return x => (true);
        }
    }
}
