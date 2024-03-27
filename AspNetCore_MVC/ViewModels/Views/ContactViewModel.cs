using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Views;

public class ContactViewModel
{
    [Display(Name = "Full name", Prompt = "Enter your full name")]
    [Required(ErrorMessage = "Full name is required")]
    public string FullName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;

    [Display(Name = "Service", Prompt = "Choose the service you are interested in")]
    public string? Service { get; set; }

    [Display(Name = "Message", Prompt = "Enter your message here...")]
    [DataType(DataType.MultilineText)]
    [Required(ErrorMessage = "Message is required")]
    public string Message { get; set; } = null!;
}
