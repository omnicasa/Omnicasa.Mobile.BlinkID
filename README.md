### This repository only implements the binding project; the version for Xamarin.Forms/NET MAUI has not been published yet. You can find those packages below on the nuget(preview version)

## Updated Apr-23-2025 Drop support for Xamarin

## BlinkID for iOS
Xamarin-iOS: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.iOS)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.iOS/)

Net8-iOS: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.Maui.iOS)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.iOS/)

## BlinkID for Droid
Xamarin-Droid: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.Droid)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Droid/)

Net8-Droid: [![NuGet Badge](https://buildstats.info/nuget/Omnicasa.Mobile.BlinkID.Maui.Droid)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Droid/)

## Nuget

| | |
|--|--|
| Binding | |
| | [Omnicasa.Mobile.BlinkID.iOS](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.iOS/2024.7.8.44-preview) |
| | [Omnicasa.Mobile.BlinkID.Droid](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Droid/2024.7.8.44-preview) |
| | [Omnicasa.Mobile.BlinkID.Maui.iOS](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.iOS/2024.7.8.44-preview) |
| | [Omnicasa.Mobile.BlinkID.Maui.Droid](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Droid/2024.7.8.44-preview) |
| Shared-Xamarin | |
| | [Omnicasa.Mobile.BlinkID.Shared](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Shared/2024.7.8.44-preview) |
| | [Omnicasa.Mobile.BlinkID.Shared.iOS](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Shared.iOS/2024.7.8.44-preview) |
| | [Omnicasa.Mobile.BlinkID.Shared.Droid](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Shared.Droid/2024.7.8.44-preview) |
| Shared Net-8 | |
| | [Omnicasa.Mobile.BlinkID.Maui.Shared](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Shared/2024.7.8.44-preview) |

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
 .Initialize("License")
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
