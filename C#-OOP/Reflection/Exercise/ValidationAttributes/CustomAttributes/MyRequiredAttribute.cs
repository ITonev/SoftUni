using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.CustomAttributes
{
    public class MyRequiredAttribute: MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var isValid = false ? obj == null : obj != null;

            return isValid;
        }
    }
}
