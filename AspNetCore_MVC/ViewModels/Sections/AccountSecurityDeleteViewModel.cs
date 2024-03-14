using AspNetCore_MVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Sections;

public class AccountSecurityDeleteViewModel
{
    [Display(Name = "Yes, I want to delete my account", Order = 0)]
    [CheckboxRequired(ErrorMessage = "Your must confirm that you want to delete your account.")]
    public bool Delete { get; set; } = false;
}
