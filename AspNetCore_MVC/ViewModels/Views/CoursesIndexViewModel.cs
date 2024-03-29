﻿using AspNetCore_MVC.ViewModels.Components;
using AspNetCore_MVC.ViewModels.Sections;
using System.Reflection;

namespace AspNetCore_MVC.ViewModels.Views;

public class CoursesIndexViewModel
{
    public string Title { get; set; } = null!;
    public CoursesViewModel Course { get; set; } = null!;
    public BannerViewModel Banner { get; set; } = null!;
}
