using Android.Content;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
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
            // アクティビティは終了するがアプリ自体は終わらないっぽいぞ？
            //context?.GetActivity()?.Finish();
            App.Current?.Quit();
        }
    }
}
