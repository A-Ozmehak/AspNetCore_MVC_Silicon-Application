﻿namespace AspNetCore_MVC.ViewModels.Components;

public class CourseViewModel
{
    public int Id { get; set; }
    public ImageViewModel? Image { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool IsBestSeller { get; set; }
    public string? LikesInNumbers { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Author { get; set; }
}
