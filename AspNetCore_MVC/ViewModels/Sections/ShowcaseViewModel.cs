﻿using AspNetCore_MVC.ViewModels.Components;

namespace AspNetCore_MVC.ViewModels.Sections;

public class ShowcaseViewModel
{
    public string? Id { get; set; }
    public ImageViewModel ShowcaseImage { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text { get; set; }
    public LinkViewModel Link { get; set; } = new LinkViewModel();
    public string? BrandsText { get; set; }
    public List<ImageViewModel>? Brands { get; set; }
}
