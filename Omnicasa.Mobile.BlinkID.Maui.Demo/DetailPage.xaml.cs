using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Newtonsoft.Json;
using Omnicasa.Mobile.BlinkID.Shared.Maui;

namespace Omnicasa.Mobile.BlinkID.Maui.Demo;

public partial class DetailPage : ContentPage
{
    public DetailPage()
    {
        InitializeComponent();
        On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);

    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        var blinkService = ServiceLocator.Current.GetInstance<IBlinkIDServiceExtended>();
        if (blinkService != null)
        {
            blinkService?
                .ScanExtended(presentAsModal: true)
                .Catch<CardRecognizerExtended?, Exception>(_ => Observable.Return<CardRecognizerExtended?>(null))
                .Subscribe(initialized =>
                {
                    System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(initialized));
                    
                });
        }
    }
}