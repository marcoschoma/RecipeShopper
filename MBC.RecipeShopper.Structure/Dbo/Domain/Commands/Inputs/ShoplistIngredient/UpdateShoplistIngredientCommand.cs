using System; 
using System.Collections.Generic; 
using System.Text; 
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Dbo; 

namespace MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient {
    
    
    public class UpdateShoplistIngredientCommand : InputCommand, ICommand {

        public virtual System.Nullable<int> ShoplistId
        {
            get;
            set;
        }

        public virtual System.Nullable<int> IngredientId
        {
            get;
            set;
        }

        public virtual System.Nullable<int> AmountTypeId
        {
            get;
            set;
        }

        public virtual System.Nullable<decimal> Amount
        {
            get;
            set;
        }
        public int Id { get; set; }
    }
}
