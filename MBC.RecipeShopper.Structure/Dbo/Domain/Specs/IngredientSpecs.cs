using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Linq;
using System.Linq.Expressions;
using MBCTech.RecipeShopper.Dbo.Domain.Entities;
using MBCTech.RecipeShopper.Dbo.Domain.Commands.Results.Ingredient;
using MBCTech.RecipeShopper.Dbo; 

namespace MBCTech.RecipeShopper.Dbo.Domain.Specs {
    
    
    public class IngredientSpecs {
        

        public static readonly Expression<Func<IngredientInfo, SelectListIngredientCommandResult>> AsSelectListIngredientCommandResult = x => new SelectListIngredientCommandResult
				{
					Id = x.Id,
					Description = x.Description,
				}
;

        public static readonly Expression<Func<IngredientInfo, PageIngredientCommandResult>> AsPageIngredientCommandResult = x => new PageIngredientCommandResult
				{
					Id = x.Id,
					Description = x.Description,
				}
;

        public static readonly Expression<Func<IngredientInfo, IngredientCommandResult>> AsIngredientCommandResult = x => new IngredientCommandResult
				{
					Id = x.Id,
					Description = x.Description,
				}
;
public static Expression<Func<IngredientInfo, bool>> TextToSearch(string textToSearch)
            {
                return x => (x.Description.Contains(textToSearch)); }
    }
}
