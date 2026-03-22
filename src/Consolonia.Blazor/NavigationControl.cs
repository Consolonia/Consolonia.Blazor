using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Blazonia.Controls;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Consolonia.Blazor
{
    public class NavigationControl<TPage> : BlazoniaNavigationControl<TPage> 
        where TPage : IComponent
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            // Register services for injectoin
            services.AddSingleton(_ =>
            {
                var lifetime =
                    (ConsoloniaLifetime)Application.Current?.ApplicationLifetime;
                ArgumentNullException.ThrowIfNull(lifetime);
                return lifetime;
            });
            services.AddSingleton(sp =>
                (IClassicDesktopStyleApplicationLifetime)sp.GetRequiredService<ConsoloniaLifetime>());
            services.AddSingleton(sp =>
                (IControlledApplicationLifetime)sp.GetRequiredService<ConsoloniaLifetime>());
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.StorageProvider);
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.Clipboard);
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.InsetsManager);
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.InputPane);
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.Launcher);
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.Screens);
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.FocusManager);
            services.AddTransient(sp =>
                sp.GetRequiredService<ConsoloniaLifetime>().MainWindow?.PlatformSettings);
        }

    }
}