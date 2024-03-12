using AspNetCore_MVC.Models.Components;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountSecurityViewModel
{
    public string Title { get; set; } = "Security";

    public AccountDetailsBasicInfoViewModel BasicInfo { get; set; } = null!;

    public AccountSecurityPasswordModel Password { get; set; } = new AccountSecurityPasswordModel();

    //public string? ErrorMessage { get; set; }
    public AccountSecurityDeleteAccountModel DeleteAccount { get; set; } = new AccountSecurityDeleteAccountModel();
}
