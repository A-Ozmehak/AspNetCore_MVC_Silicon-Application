using AspNetCore_MVC.Models.Components;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
    {
        ProfileImage = "images/avatar.svg",
        FirstName = "Anna",
        LastName = "Ozmehak",
        Email = "anna.ozmehak@gmail.com"
    };
    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();
}
