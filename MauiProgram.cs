using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using fwd_bilvaerksted.ViewModels;
using fwd_bilvaerksted.Pages;
using fwd_bilvaerksted.Data;

namespace fwd_bilvaerksted;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Logging.AddDebug();

        builder.Services.AddSingleton<Database>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<WorkOrderViewModel>();
        builder.Services.AddTransient<BookWorkOrder>();
        builder.Services.AddTransient<OrderOverviewViewModel>();
        builder.Services.AddTransient<OrderOverviewPage>();
        builder.Services.AddTransient<CreateInvoiceViewModel>();
        builder.Services.AddTransient<CreateInvoicePage>();
        builder.Services.AddTransient<ViewInvoicesViewModel>();
        builder.Services.AddTransient<ViewInvoicesPage>();

        return builder.Build();
    }
}
