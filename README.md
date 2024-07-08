c### This repository only implements the binding project; the version for Xamarin.Forms/NET MAUI has not been published yet.

## BlinkID for iOS
Xamarin-iOS: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.iOS)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.iOS/)

Net8-iOS: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.Maui.iOS)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.iOS/)

## BlinkID for Droid
Xamarin-Droid: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.Droid)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Droid/)

Net8-Droid: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.Maui.Droid)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Droid/)


### Use DI
```csharp
container.Register<IBlinkIDService, BlinkIDService>();

private IBlinkIDService GetBlinkIDService()
{
 return StandardLocator?.Resolve<IBlinkIDService>();
}
```

### Initialize
```csharp
GetBlinkIDService()
 .Initialize(Omnicasa.Mobile.SingleModules.BlinkIDKit.BlinkIDUtils.iOSLic)
 .Subscribe(success =>
 {
 System.Diagnostics.Debug.WriteLine($"Subscribe GetBlinkIDService: {success}");
 });
```

### Scaning
```csharp
BlinkIDService?
 .Scan()
 .Catch((Exception e) =>
 {
 System.Diagnostics.Debug.WriteLine(e.StackTrace);
 return Observable.Return<CardRecognizer>(null);
 })
 .Subscribe(card =>
 {
 System.Diagnostics.Debug.WriteLine(card.FirstName);
 });
```
