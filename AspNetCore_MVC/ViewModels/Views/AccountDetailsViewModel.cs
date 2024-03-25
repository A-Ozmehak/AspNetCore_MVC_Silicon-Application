using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel? ProfileInfo { get; set; }
    public AccountDetailsBasicInfoViewModel? BasicInfo { get; set; }
    public AccountDetailsAddressInfoViewModel? AddressInfo { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? ProfileImageUrl { get; set; }
    public bool IsExternalAccount { get; set; }
}
