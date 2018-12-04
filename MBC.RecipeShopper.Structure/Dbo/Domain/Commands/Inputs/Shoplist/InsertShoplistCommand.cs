using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist {
    
    
    public class InsertShoplistCommand : InputCommand, ICommand {

        public virtual System.Nullable<int> RecipeId
        {
            get;
            set;
        }

        public virtual System.DateTime CreationDate {
            get;
            set;
        }
    }

    public class InsertShoplistWithIngredientsCommand : InputCommand, ICommand
    {

        public virtual System.DateTime CreationDate
        {
            get;
            set;
        }

        public virtual ICollection<InsertShoplistIngredientCommand> ShoplistsIngredients
        {
            get;
            set;
        }
    }
}
