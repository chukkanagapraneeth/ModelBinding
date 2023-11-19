using ModelBinding.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBinding.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string? PropertyName { get; set; }
        
        public DateRangeValidatorAttribute(string OtherPropertyName)
        {
            PropertyName = OtherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {              
            if (value != null)
            {
                DateTime to_date = Convert.ToDateTime(value);

                if (PropertyName != null)
                {
                    var model = (User)validationContext.ObjectInstance;
                    PropertyInfo? otherproperty = validationContext.ObjectType.GetProperty(PropertyName);

                    DateTime from_date = Convert.ToDateTime(otherproperty.GetValue(validationContext.ObjectInstance));

                    if(from_date < to_date)
                    {
                        return ValidationResult.Success;
                    }
                }
                {
                    return new ValidationResult("Please provide From Date");
                }
            }
            else
            {
                return new ValidationResult("Please provide To Date");
            }
        }
    }
}
