using AspNetCore_MVC.Models.Views;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Views;

public class SignInViewModel
{
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;


    [DataType(DataType.Password)]
    [Display(Name = "Password", Prompt = "Enter your password")]
    [Required(ErrorMessage = "A valid password is required")]
    public string Password { get; set; } = null!;

    public bool RememberMe { get; set; }
}
