using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
           

            foreach (MethodInfo method in type.GetMethods((BindingFlags)60))
            {
                if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        if (attributes != null)
                        {
                            Console.WriteLine($"{method.Name} is written by {attr.Name}");
                        }
                    }
                }
            }

        }
    }
}
