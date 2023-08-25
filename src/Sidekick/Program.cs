using ElectronNET.API;
using ElectronNET.API.Entities;
using Sidekick;
using Sidekick.Common;
using Sidekick.Common.Blazor.Views;
using Sidekick.Common.Platform;
using Sidekick.Electron;
using Sidekick.Mock;
using Sidekick.Modules.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseElectron(args);

#region Configuration

builder.Configuration.AddJsonFile(SidekickPaths.GetDataFilePath(SettingsService.FileName), true, true);

#endregion Configuration

#region Services

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddLocalization();

builder.Services.AddSidekick(builder.Configuration);

if (HybridSupport.IsElectronActive)
{
    builder.Services.AddSingleton<IApplicationService, ElectronApplicationService>();
    builder.Services.AddSingleton<ITrayProvider, ElectronTrayProvider>();
    builder.Services.AddSingleton<IViewLocator, ElectronViewLocator>();
}
else
{
    builder.Services.AddSingleton<IApplicationService, MockApplicationService>();
    builder.Services.AddSingleton<ITrayProvider, MockTrayProvider>();
    builder.Services.AddSingleton<IViewLocator, MockViewLocator>();
}

builder.Services.AddHttpClient();
builder.Services.AddLocalization();

#endregion Services

var app = builder.Build();

#region Pipeline

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

#endregion Pipeline

if (HybridSupport.IsElectronActive)
{
    var viewLocator = app.Services.GetRequiredService<IViewLocator>();
    await viewLocator.Open("/initialize");

    // We need to trick Electron into thinking that our app is ready to be opened.
    // This makes Electron hide the splashscreen. For us, it means we are ready to initialize and price check :)
    var browserWindow = await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
    {
        Width = 1,
        Height = 1,
        Frame = false,
        Show = true,
        Transparent = true,
        Fullscreenable = false,
        Minimizable = false,
        Maximizable = false,
        SkipTaskbar = true,
        WebPreferences = new WebPreferences()
        {
            NodeIntegration = false,
        }
    });
    browserWindow.WebContents.OnCrashed += (killed) => Electron.App.Exit();
    await Task.Delay(50);
    browserWindow.Hide();
}

app.Run();
