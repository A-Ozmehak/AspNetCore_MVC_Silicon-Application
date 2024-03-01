using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.Models.Components;

public class AccountSecurityPasswordModel
{
    [Display(Name = "Current Password", Prompt = "Enter your current password", Order = 0)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Your current password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password, must be a strong password")]
    public string CurrentPassword { get; set; } = null!;

    [Display(Name = "New Password", Prompt = "Your new password", Order = 1)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Your new password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Invalid password, must be a strong password")]
    public string NewPassword { get; set; } = null!; 

    [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 2)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password much be confirmed")]
    [Compare(nameof(NewPassword), ErrorMessage = "Fields does not match")]
    public string ConfirmPassword { get; set; } = null!;
}
