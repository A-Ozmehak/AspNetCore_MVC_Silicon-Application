namespace AspNetCore_MVC.ViewModels.Views;

public class AccountSavedCoursesViewModel
{
    public string Title { get; set; } = "Saved Items";
    public ProfileInfoViewModel? ProfileInfo { get; set; }
    public AccountDetailsBasicInfoViewModel? BasicInfo { get; set; }

}
