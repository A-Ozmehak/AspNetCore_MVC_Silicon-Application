using AspNetCore_MVC.Models.Components;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountSavedCoursesViewModel
{
    public string Title { get; set; } = "Saved Items";
    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
    {
        ProfileImage = "images/avatar.svg",
        FirstName = "Anna",
        LastName = "Ozmehak",
        Email = "anna.ozmehak@gmail.com"
    };
}
