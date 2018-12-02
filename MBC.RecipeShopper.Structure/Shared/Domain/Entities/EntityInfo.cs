using MBC.RecipeShopper.Shared.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using MBC.RecipeShopper.Shared.Infra;
using System.Reflection;

namespace MBC.RecipeShopper.Shared.Domain.Entities
{
    public class EntityInfo : NotifiableEntityInfo
    {
        public void Map(InputCommand inputCommand)
        {
            foreach (var propertyInfo in inputCommand.GetType().GetProperties())
            {
                GetType()
                    .GetProperty(propertyInfo.Name,
                        BindingFlags.IgnoreCase |
                        BindingFlags.Instance |
                        BindingFlags.Public)
                    .SetValue(this,
                        propertyInfo.GetValue(inputCommand));
            }
        }
    }
}
