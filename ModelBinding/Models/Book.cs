using Microsoft.AspNetCore.Mvc;
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

    public class User
    {
        [Required(ErrorMessage = "{0} is Empty")]
        [Display(Name = "Peru")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "{0} should be {2} and {1} lenghth long")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is Empty")]
        [EmailAddress(ErrorMessage = "Give a proper email g")]
        public string? Email { get; set; }

        [Range(20, maximum: 65, ErrorMessage = "{0} should be between {1} and {2}")]
        public int Age { get; set; }

        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "only alpha space dot chars are allowed")]
        public string? School { get; set; }

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Password must be between {1} to {2} characters")]
        [Required]
        public string? password { get; set; }

        [Compare("password", ErrorMessage = "{0} Doesn't match with password")]
        [Required]
        public string? confirmpassword { get; set; }

    }
}
