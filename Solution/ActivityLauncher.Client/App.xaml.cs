﻿namespace ActivityLauncher.Client;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Title = "Activity Launcher for Windows";

        return window;
    }
}
