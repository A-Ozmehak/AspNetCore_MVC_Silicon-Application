using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Components;

public class UploadProfileImageViewModel
{
    [DataType(DataType.Upload)]
    public IFormFile? ProfileImage { get; set; }
}
