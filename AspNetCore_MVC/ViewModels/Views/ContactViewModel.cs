using AspNetCore_MVC.Models.Views;

namespace AspNetCore_MVC.ViewModels.Views;

public class ContactViewModel
{
    public ContactModel Form { get; set; } = new ContactModel();
}
