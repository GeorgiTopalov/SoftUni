using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type type = Type.GetType(className);
            FieldInfo[] classFields = type.GetFields((BindingFlags)60);

            StringBuilder sb = new StringBuilder();

            Object instance = Activator.CreateInstance(type, new object[] { });

            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in classFields)
            {
                if (fields.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
