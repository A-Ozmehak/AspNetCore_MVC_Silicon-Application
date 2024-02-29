using AspNetCore_MVC.Models.Views;
using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Sections;

namespace AspNetCore_MVC.ViewModels.Views;

public class ContactViewModel
{
    public string Title { get; set; } = null!;

    public ContactContentViewModel Content { get; set; } = null!;
    public ContactModel Form { get; set; } = new ContactModel();
}
