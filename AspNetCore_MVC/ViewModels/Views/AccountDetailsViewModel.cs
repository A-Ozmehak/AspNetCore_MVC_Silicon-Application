namespace AspNetCore_MVC.ViewModels.Views;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel? ProfileInfo { get; set; }
    public AccountDetailsBasicInfoViewModel? BasicInfo { get; set; }
    public AccountDetailsAddressInfoViewModel? AddressInfo { get; set; }
    public bool IsExternalAccount { get; set; }
}
