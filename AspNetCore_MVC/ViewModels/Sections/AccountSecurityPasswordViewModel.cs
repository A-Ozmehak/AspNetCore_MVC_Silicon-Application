using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Sections;

public class AccountSecurityPasswordViewModel
{
    [Display(Name = "Current Password", Prompt = "Enter your current password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Your current password is required")]
    public string CurrentPassword { get; set; } = null!;

    [Display(Name = "New Password", Prompt = "Your new password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Your new password is required")]
    public string NewPassword { get; set; } = null!;

    [Display(Name = "Confirm password", Prompt = "Confirm your password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password much be confirmed")]
    [Compare(nameof(NewPassword), ErrorMessage = "Fields does not match")]
    public string ConfirmPassword { get; set; } = null!;
}
