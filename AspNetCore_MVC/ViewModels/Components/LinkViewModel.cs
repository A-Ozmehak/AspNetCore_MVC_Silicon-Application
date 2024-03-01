﻿namespace AspNetCore_MVC.ViewModels.Components;

public class LinkViewModel
{
    public string ControllerName { get; set; } = null!;
    public string ActionName { get; set; } = null!;
    public string Text { get; set; } = null!;
    public string? Icon { get; set; }
}
