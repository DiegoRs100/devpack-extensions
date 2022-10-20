using System.ComponentModel;

namespace Devpack.Extensions.Helpers
{
    public static class EnumHelper
    {
        public static TEnum? GetByDescription<TEnum>(string description) where TEnum : struct
        {
            description = description.ToLower();

            foreach (var field in typeof(TEnum).GetFields())
            {
                var aux = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                if (aux is null && field.Name.ToLower() == description)
                    return (TEnum?)field.GetValue(null);

                if (aux is DescriptionAttribute attribute && attribute.Description.ToLower() == description)
                    return (TEnum?)field.GetValue(null);
            }

            return null;
        }
    }
}