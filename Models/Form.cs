#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSub.Models;

public class Form
{
    [Required(ErrorMessage = "is required")]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    [IsValidEmail]
    public string Email { get; set; }

    [Required]
    [DateCheck]
    public DateTime DOB { get; set; }

    [Required]
    [MinLength(8)]
    public string Password { get; set; }

    [Required]
    [OddValid]
    public int FavOddNum { get; set; }

}


// Create a class that inherits from ValidationAttribute
public class DateCheckAttribute : ValidationAttribute
{
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {

        if (value == null || (DateTime)value >= DateTime.Now)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Please Enter a Valid Date");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}

//check email format
//EmailAddressAttribute
public class IsValidEmailAttribute : ValidationAttribute
{
    // Call upon the protected IsValid method
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        EmailAddressAttribute e = new EmailAddressAttribute();
        if (value == null || !e.IsValid(value))
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Please Enter a Valid Email");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}

//fav odd
public class OddValidAttribute : ValidationAttribute
{
    // Call upon the protected IsValid method
    

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {



        if (value == null || (int)value % 2 == 0)
        {
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("Please an Prime number :)!");
        }
        else
        {
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;
        }
    }
}
