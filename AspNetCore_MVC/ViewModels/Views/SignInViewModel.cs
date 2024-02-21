using AspNetCore_MVC.Models.Views;

namespace AspNetCore_MVC.ViewModels.Views;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";
    public SignInModel Form { get; set; } = new SignInModel();
    public string? ErrorMessage { get; set; }
}
