This repository implements the BlinkID binding project for Xamarin.Forms and .NET MAUI. The binding provides C# wrappers for the BlinkID Android and iOS SDKs.

## Updated Apr-23-2025 Drop support for Xamarin

## Project Structure

- Omnicasa.Mobile.BlinkID.Droid - Xamarin Android binding for BlinkID Core
- Omnicasa.Mobile.BlinkID.iOS - Xamarin iOS binding for BlinkID
- Omnicasa.Mobile.BlinkID.Maui.Droid - .NET MAUI Android binding for BlinkID Core
- Omnicasa.Mobile.BlinkID.Maui.iOS - .NET MAUI iOS binding for BlinkID
- Omnicasa.Mobile.BlinkID.UX.Maui.Droid - .NET MAUI Android binding for BlinkID UX (currently uses Core only)
- Omnicasa.Mobile.BlinkID.Shared - Shared code for Xamarin projects
- Omnicasa.Mobile.BlinkID.Shared.Maui - Shared code for .NET MAUI projects

## BlinkID Version

Current binding supports BlinkID SDK version 7.5.0.

## Binding Notes

- Kotlin suspend functions (like initializeSdk) cannot be directly bound to C# due to Continuation parameter limitations
- The binding generates 115+ C# classes from the core BlinkID AAR

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

### Scanning
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
