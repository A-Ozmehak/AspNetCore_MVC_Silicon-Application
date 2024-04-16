using AspNetCore_MVC.ViewModels.Sections;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountSecurityViewModel
{
    public string Title { get; set; } = "Security";

    public ProfileInfoViewModel? ProfileInfo { get; set; }
    public AccountDetailsBasicInfoViewModel? BasicInfo { get; set; }

    public AccountSecurityPasswordViewModel? Password { get; set; }

    public AccountSecurityDeleteViewModel? DeleteAccount { get; set; }
}
