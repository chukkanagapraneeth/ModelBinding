using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinding.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding.Models
{
    public class Book
    {
        public string? Author { get; set; }
        [FromQuery]
        public int? Bookid { get; set; }

        public override string ToString()
        {
            return $"Bookid : {Bookid}, Author: {Author}";
        }
    }

    public class User : IValidatableObject
    {
        [Required(ErrorMessage = "{0} is Empty")]
        [Display(Name = "Peru")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "{0} should be {2} and {1} lenghth long")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is Empty")]
        [EmailAddress(ErrorMessage = "Give a proper email g")]
        public string? Email { get; set; }

        [Range(20, maximum: 65, ErrorMessage = "{0} should be between {1} and {2}")]
        public int? Age { get; set; }

        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "only alpha space dot chars are allowed")]
        public string? School { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Password must be between {1} to {2} characters")]
        [Required]
        public string? password { get; set; }

        [Compare("password", ErrorMessage = "{0} Doesn't match with password")]
        [Required]
        public string? confirmpassword { get; set; }

        //CUSTOM VALIDATION ATTRIBUTE
        //[DobValidation(DateOfBirth = Convert.ToDateTime("2000-12-12"),ErrorMessage = "Date should be greater than 2000 bruv")]

        [DobValidation(DOB: "2000-12-12", ErrorMessage = "Year should be less than {0} for {1} parameter")]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }

        //Multiple Properties using Reflection
        public string? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "From Date should be less than To Date.")]
        public string? ToDate { get; set; }

        // Collection Binding
        public List<string?> Tags { get; set; } = new List<string?>();

        //IMPLEMENTING IVALIDATABLEOBJECT - for quick validation and non re usable
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either date of birth or Age must be supplied", new[] { nameof(DateOfBirth)});
            } 
        }
    }
}
