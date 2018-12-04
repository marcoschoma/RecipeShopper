using System.Reflection;
using MBC.RecipeShopper.Shared.Domain.Commands;
using MBC.RecipeShopper.Shared.Infra;

namespace MBC.RecipeShopper.Shared.Domain.Entities
{
    public class EntityInfo : NotifiableEntityInfo
    {
        public void Map(InputCommand inputCommand)
        {
            foreach (var propertyInfo in inputCommand.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(inputCommand) != null)
                {
                    var targetProperty = GetType()
                        .GetProperty(propertyInfo.Name,
                            BindingFlags.IgnoreCase |
                            BindingFlags.Instance |
                            BindingFlags.Public);
                    if (targetProperty != null && targetProperty.PropertyType == propertyInfo.PropertyType)
                    {
                        targetProperty.SetValue(this,
                                propertyInfo.GetValue(inputCommand));
                    }
                }
            }
        }
    }
}
