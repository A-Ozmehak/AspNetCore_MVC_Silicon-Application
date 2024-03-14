using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Views;

public class AccountDetailsAddressInfoViewModel
{
    [Required(ErrorMessage = "A address is required")]
    [Display(Name = "Address line 1", Prompt = "Enter your address")]
    [DataType(DataType.Text)]
    public string AddressLine_1 { get; set; } = null!;


    [Display(Name = "Address line 2 (optional)", Prompt = "Enter your second address")]
    [DataType(DataType.Text)]
    public string? AddressLine_2 { get; set; }


    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [Required(ErrorMessage = "Postal code is required")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City", Prompt = "Enter your city")]
    [Required(ErrorMessage = "City is required")]
    [DataType(DataType.Text)]
    public string City { get; set; } = null!;
}
