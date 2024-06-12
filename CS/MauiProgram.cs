using DevExpress.Drawing.Internal;
using DevExpress.Maui;
using Microsoft.Extensions.Logging;

namespace FillPDFFile;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseDevExpressCollectionView()
            .UseDevExpressControls()
            .UseDevExpressEditors()
            .UseDevExpressPdf()
            .UseDevExpress()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //#if DEBUG
        //        builder.Logging.AddDebug();
        //#endif

        return builder.Build();
    }
}
