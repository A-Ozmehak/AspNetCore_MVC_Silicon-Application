using AspNetCore_MVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.Models.Components;

public class AccountSecurityDeleteAccountModel
{
    [Display(Name = "Yes, I want to delete my account", Order = 0)]
    [CheckboxRequired(ErrorMessage = "Your must confirm that you want to delete your account.")]
    public bool Delete { get; set; } = false;
}
