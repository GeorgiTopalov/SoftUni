using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool isValid(object person)
        {
            PropertyInfo[] propertiesInfo = person
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any())
                .ToArray();

            foreach (PropertyInfo propertyInfo in propertiesInfo)
            {
                var value = propertyInfo.GetValue(person);
                MyValidationAttribute attribute = propertyInfo.GetCustomAttribute<MyValidationAttribute>();

            bool isValid = attribute.isValid(value);

                if (isValid)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
