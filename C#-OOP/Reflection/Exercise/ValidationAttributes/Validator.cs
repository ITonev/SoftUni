using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var type = obj.GetType();

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var currentAttributes = property
                    .GetCustomAttributes()
                    .Where(x=>x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var att in currentAttributes)
                {
                    if (!att.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }                    
                }
            }

            return true;
        }
    }
}
