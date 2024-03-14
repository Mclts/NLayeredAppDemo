using FluentValidation;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Utilities
{
    //Bu class için ihtiyacımız olan şeyler bir validator oluşturmak ve neyi validate ediceğimizi vermek.
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity) 
        {
            var result = validator.Validate((IValidationContext)entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
