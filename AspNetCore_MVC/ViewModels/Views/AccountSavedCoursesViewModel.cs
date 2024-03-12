using AspNetCore_MVC.Models.Components;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountSavedCoursesViewModel
{
    public string Title { get; set; } = "Saved Items";
    public ProfileInfoViewModel? ProfileInfo { get; set; }

}
