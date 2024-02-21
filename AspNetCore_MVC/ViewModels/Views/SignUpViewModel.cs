using AspNetCore_MVC.Models.Views;

namespace AspNetCore_MVC.ViewModels.Views;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign up";
    public SignUpModel Form { get; set; } = new SignUpModel();
}
