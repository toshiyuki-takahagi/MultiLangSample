using Microsoft.Maui.Platform;
using System.Diagnostics;
using System.Globalization;

namespace MultiLangSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // テーマの変更は追跡してくれるっぽい(一応トレースを挟み込んでおく)
            RequestedThemeChanged += (s, e) =>
            {
                Trace.WriteLine($"Called RequestedThemeChanged( {s?.GetType().Name}, {e.RequestedTheme})");
            };

            MainPage = new AppShell();
        }

    }
}
