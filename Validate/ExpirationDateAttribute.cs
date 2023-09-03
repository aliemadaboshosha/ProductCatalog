using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace a_product_catalog.Validate
{
    public class ExpirationDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date) { return date > DateTime.Now.Date; }

            return false;
        }
        
    }
}
