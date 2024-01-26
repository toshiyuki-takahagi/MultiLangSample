using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using MultiLangSample.Platforms.Android;

namespace MultiLangSample;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density/* | ConfigChanges.Locale | ConfigChanges.ColorMode*/)]
public partial class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        System.Diagnostics.Debug.WriteLine("Called OnCreate()");
        base.OnCreate(savedInstanceState);
        // Localeの変更は2種類ある
        RegisterReceiver(new TraceChangedReceiver(ChangeActionTarget.SystemLangauage), new IntentFilter(Android.Content.Intent.ActionLocaleChanged));
        RegisterReceiver(new TraceChangedReceiver(ChangeActionTarget.ApplicationLanguage), new IntentFilter(Android.Content.Intent.ActionApplicationLocaleChanged));
        // 試しにConfigrationChanged もこっちで受け取ってみる
        RegisterReceiver(new TraceChangedReceiver(ChangeActionTarget.Configuration), new IntentFilter(Android.Content.Intent.ActionConfigurationChanged));
    }

    public override void OnConfigurationChanged(Configuration newConfig)
    {
        System.Diagnostics.Debug.WriteLine($"newConfig.ColorMode={newConfig.ColorMode}");
        System.Diagnostics.Debug.WriteLine($"newConfig.Locale={newConfig.Locale?.DisplayName ?? "null"}");
        base.OnConfigurationChanged(newConfig);
    }
}
