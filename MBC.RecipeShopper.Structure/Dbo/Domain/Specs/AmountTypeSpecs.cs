using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using MBC.RecipeShopper.Dbo.Domain.Entities;
using MBC.RecipeShopper.Dbo.Domain.Commands.Results.AmountType;
using MBC.RecipeShopper.Dbo;

namespace MBC.RecipeShopper.Dbo.Domain.Specs
{


    public class AmountTypeSpecs
    {


        public static readonly Expression<Func<AmountTypeInfo, SelectListAmountTypeCommandResult>> AsSelectListAmountTypeCommandResult = x => new SelectListAmountTypeCommandResult
        {
            Id = x.Id,
            Description = x.Description,
        }
;

        public static readonly Expression<Func<AmountTypeInfo, PageAmountTypeCommandResult>> AsPageAmountTypeCommandResult = x => new PageAmountTypeCommandResult
        {
            Id = x.Id,
            Description = x.Description,
        }
;

        public static readonly Expression<Func<AmountTypeInfo, AmountTypeCommandResult>> AsAmountTypeCommandResult = x => new AmountTypeCommandResult
        {
            Id = x.Id,
            Description = x.Description,
        }
;
        public static Expression<Func<AmountTypeInfo, bool>> TextToSearch(string textToSearch)
        {
            return x => (x.Description.Contains(textToSearch));
        }
    }
}
