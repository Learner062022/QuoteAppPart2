﻿namespace DylanDeSouzaQuoteAppPart1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState) =>
            new(new AppShell());
    }
}