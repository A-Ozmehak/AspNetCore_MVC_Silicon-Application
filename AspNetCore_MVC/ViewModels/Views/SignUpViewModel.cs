using AspNetCore_MVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Views;

public class SignUpViewModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;


    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;


    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;


    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "A valid password is required")]
    public string Password { get; set; } = null!;


    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage = "Password must be confirmed")]
    public string ConfirmPassword { get; set; } = null!;


    [Required(ErrorMessage = "Terms and conditions must be accepted")]
    [CheckboxRequired(ErrorMessage = "Your must accept the terms and conditions to proceed.")]
    public bool TermsAndConditions { get; set; }
}
