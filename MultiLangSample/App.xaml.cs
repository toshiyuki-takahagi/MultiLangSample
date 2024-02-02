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
        public void ChangeTheme(AppTheme appTheme)
        {
            // 現在のテーマ設定がシステムと同じでデフォルトに戻す場合は一度色を強制的に切り替える必要があるっぽい
            if (appTheme == AppTheme.Unspecified && UserAppTheme == RequestedTheme)
            {
                // 一度システムと異なるモードにしてやらないとiOSはうまくいかないっぽい
                UserAppTheme = RequestedTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;
            }
            UserAppTheme = appTheme;
        }

    }
}
