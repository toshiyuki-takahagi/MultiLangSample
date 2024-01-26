using Android.App;
using Android.Content;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLangSample.Platforms.Android;

enum ChangeActionTarget
{
    Configuration,
    SystemLangauage,
    ApplicationLanguage,
}
internal class TraceChangedReceiver(ChangeActionTarget action_ ) : BroadcastReceiver
{
    public override void OnReceive(Context? context, Intent? intent)
    {
        System.Diagnostics.Debug.WriteLine($"TraceChangedReceiver( {action_} ).OnReceive( intent: {intent} )");
        if( action_ == ChangeActionTarget.SystemLangauage || action_ == ChangeActionTarget.ApplicationLanguage)
        {
            var localeManager = context?.GetSystemService(Context.LocaleService) as LocaleManager;
            if (localeManager != null)
            {
                var locales = localeManager.ApplicationLocales;
                if (locales == null || locales.IsEmpty)
                {
                    locales = localeManager.SystemLocales;
                }
                if (locales != null && !locales.IsEmpty)
                {
                    //  最初に出てきたロケールを利用する
                    var locale = locales.Get(0);
                    if (locale != null)
                    {
                        var lang= $"{locale.Language}-{locale.Country}";
                        var culture = CultureInfo.CreateSpecificCulture(lang);
                        if( culture != null )
                        {
                            CultureInfo.CurrentCulture = culture;
                            CultureInfo.CurrentUICulture = culture;
                            // Finishしちゃうと、Lionrock はまずいかもしれない。その場合はこの方法はダメ。
                            context?.GetActivity()?.Finish();
                        }
                    }
                    //int count = locales.Size();
                    //System.Diagnostics.Debug.WriteLine($"isSystemLocale={isSystemLocale}, locales.Size()={count}");
                    //for (int index = 0; index < count; index++)
                    //{
                    //    var locale = locales.Get(index);
                    //    System.Diagnostics.Debug.WriteLine(locale);
                    //}
                }
            }


            // アクティビティは終了するがアプリ自体は終わらないっぽいぞ？
            //context?.GetActivity()?.Finish();
            //App.Current?.Quit();
        }
    }
}
