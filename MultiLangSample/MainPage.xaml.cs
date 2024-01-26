namespace MultiLangSample;

using System.Diagnostics;
using System.Globalization;
using ResourceStrings = MultiLang.Resources.Properties.Resources;

public partial class MainPage : ContentPage
{
    int count = 0;
    bool systemDefault;

    public MainPage()
    {
        InitializeComponent();

        systemDefault = true;
        ColorPicker.SelectedIndex = 0; // 初期値はシステムデフォルト

    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        var formatString = count == 1 ? ResourceStrings.MainPage_ButtonFace_1st_Clicked : ResourceStrings.MainPage_ButtonFace_2nd_Clicked;
        CounterBtn.Text = string.Format(formatString, count);

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //    var newCultureInfo = default(CultureInfo);
    //    if (CultureInfo.CurrentUICulture.IetfLanguageTag.Contains("ja"))
    //    {
    //        newCultureInfo = CultureInfo.CreateSpecificCulture("en-us");
    //    }
    //    else
    //    {
    //        newCultureInfo = CultureInfo.CreateSpecificCulture("ja");
    //    }
    //    if( Application.Current is App app )
    //    {
    //        app.RequestCulture = newCultureInfo;
    //        app.UserAppTheme = app.RequestedTheme == AppTheme.Dark ? AppTheme.Light : AppTheme.Dark;
    //    }
    //    // このページをリロードさせる(ページの再遷移を行う)
    //    //foreach (var window in Application.Current?.Windows)
    //    //{
    //    //}
    //}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sender is Picker picker)
        {
            // インデックスで区別できるのでそのままキャストしてセットアップする
            if( Application.Current != null)
            {
                Application.Current.UserAppTheme = (AppTheme)picker.SelectedIndex;
            }
        }
    }
}
