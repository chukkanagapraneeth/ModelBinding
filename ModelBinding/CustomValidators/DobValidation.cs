using System.ComponentModel.DataAnnotations;

namespace ModelBinding.CustomValidators
{
    public class DobValidation : ValidationAttribute
    {
        // PROPERTIES
        public DateTime DateOfBirth { get; set; } = Convert.ToDateTime("2000-01-01");
        public String DefaultErrorMessage { get; set; } = "Minimum year allowed is {0} for {1}";

        // CONSTRUCTOR
        public DobValidation(String DOB)
        {
            DateOfBirth = Convert.ToDateTime(DOB);
        }

        // OVERRIDE the IsValid METHOD

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime dob = Convert.ToDateTime(value);
                if (dob.Year > DateOfBirth.Year)
                {
                    //return new ValidationResult("Min year allowed is 2000.");

                    // {0} is DateOfBirth.Year and {1} is validationContext.DisplayName the property name
                    return new ValidationResult(String.Format(ErrorMessage ?? DefaultErrorMessage, DateOfBirth.Year, validationContext.DisplayName));
                }
            }
            else
            {
                return ValidationResult.Success;
            }
            return null;           
        }

    }
}
