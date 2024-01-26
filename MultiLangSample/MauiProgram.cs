using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace MultiLangSample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-us");
            //Trace.WriteLine(CultureInfo.CurrentUICulture);
            //CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("ja");
            //CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("ja");
            //MultiLang.Strings.Properties.Resources.Culture = CultureInfo.CurrentUICulture;
            //var value = MultiLang.Strings.Properties.Resources.MainPage_Subject;
            //Trace.WriteLine(value);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
