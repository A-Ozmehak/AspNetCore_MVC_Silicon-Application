using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Sections;

public class NewsletterViewModel
{
    [Display(Name = "Daily Newsletter")]
    public bool DailyNewsletter { get; set; } = false;

    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; } = false;

    [Display(Name = "Week in Review")]
    public bool WeekInReview { get; set; } = false;

    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; } = false;

    [Display(Name = "Startups Weekly")]
    public bool StartupsWeekly { get; set; } = false;

    [Display(Name = "Podcasts")]
    public bool Podcasts { get; set; } = false;

    [Display(Name = "Email address", Prompt = "Your email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;
}
