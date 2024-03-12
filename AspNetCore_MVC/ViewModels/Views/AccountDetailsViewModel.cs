using AspNetCore_MVC.Models.Components;
using Infrastructure.Entities;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountDetailsViewModel
{
    public ProfileInfoViewModel? ProfileInfo { get; set; }
    public AccountDetailsBasicInfoViewModel? BasicInfo { get; set; }
    public AccountDetailsAddressInfoViewModel? AddressInfo { get; set; }
}
