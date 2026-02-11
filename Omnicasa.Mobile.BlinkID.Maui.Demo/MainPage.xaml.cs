using System.Reactive.Linq;
using CommonServiceLocator;
using Newtonsoft.Json;
using Omnicasa.Mobile.BlinkID.Shared.Maui;

namespace Omnicasa.Mobile.BlinkID.Maui.Demo;

public partial class MainPage : ContentPage
{
    private const string IosLic = "sRwAAAETY29tLm9tbmljYXNhLm1vYmlsZXEPe6POZt4PSoCbv7EneOY6qMOcReFvL6VLejgXyGu/S7xlYbv6QgiyU/fYd8harXPQGCVH4xKMRD0blOjniQtx5Fv97rt7lrlNpr885nqSXcb83vXEjvxGkhLbN8VFIXCWV/GZpQonCwmVPTgs9jF9a2HX1pu3/mROCDKCQ5KiT5h8MRhMLyih2g2aXWKgtbQ0bcWU";

    private const string DroidLic = "sRwAAAATY29tLm9tbmljYXNhLm1vYmlsZWIBD4xeaH4PRjTgkGPcb9r31QSc35hNGegKgsEoRhc4c0FT1RXwrk2OWBo1jzWcdOOqB9jgYCoWxtBLHJTgV1bo77X8aAsEpC93GXnrybsMemrnRY886Cnf5RXtesCjLFq3SzDq6l7uLzNnDmfzSJf+HhLArsD/80fjh6G/O6cgYHzlPy5J94utkLBO3GCaGM1mQFb4";

    public MainPage()
    {
        InitializeComponent();
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
        var blinkService = ServiceLocator.Current.GetInstance<IBlinkIDServiceExtended>();
        if (blinkService != null)
        {
            blinkService
                .Initialize(Microsoft.Maui.Devices.DeviceInfo.Platform == DevicePlatform.iOS ?
                    IosLic : DroidLic)
                .Catch<bool, Exception>(_ => Observable.Return(false))
                .Subscribe(initialized =>
                {
                    System.Diagnostics.Debug.WriteLine($"Register BLINKID with result => {initialized}");
                });
        }
    }

    private void OnScanClicked(object sender, EventArgs e)
    {
        var blinkService = ServiceLocator.Current.GetInstance<IBlinkIDServiceExtended>();
        if (blinkService != null)
        {
            blinkService?
                .ScanExtended()
                .Catch<CardRecognizerExtended?, Exception>(_ => Observable.Return<CardRecognizerExtended?>(null))
                .Subscribe(initialized =>
                {
                    System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(initialized));
                    imageTest.Source = initialized?.FullDocumentFrontImage;
                    imageTest2.Source = initialized?.FullDocumentBackImage;
                    imageTest3.Source = initialized?.FaceImage;
                    imageTest4.Source = initialized?.SignatureImage;
                });
        }
    }

    private void ScanBtn2_OnClicked(object? sender, EventArgs e)
    {
        Navigation.PushModalAsync(new DetailPage());
    }
}


