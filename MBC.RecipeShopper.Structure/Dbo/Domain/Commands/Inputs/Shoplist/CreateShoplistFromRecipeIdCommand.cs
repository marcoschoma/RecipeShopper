using System;
using MBC.RecipeShopper.Shared.Domain.Commands;

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist
{
    public class CreateShoplistFromRecipeIdCommand : InputCommand, ICommand
    {
        public virtual int[] RecipeId
        {
            get;
            set;
        }
    }
}
