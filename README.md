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

Current binding supports BlinkID SDK version 8000.0.0 (Microblink's version string for v8).

- **Android** — binds `blinkid-core` / `blinkid-ux` directly. v8 folded the old
  `microblink-ux` artifact into `blinkid-ux`, so there is no separate UI aar.
- **iOS** — v8 is pure Swift and exports no Objective-C surface, so it cannot be bound
  directly. `NativeShim/` wraps it in a small `@objc` framework which is what the
  binding actually targets. Run `NativeShim/build.sh` after changing the shim; the
  resulting `NativeLib/OmnBlinkIDShim.xcframework` is committed like the other natives.

## Binding Notes

- Kotlin suspend functions (like initializeSdk) cannot be directly bound to C# due to Continuation parameter limitations
- The binding generates 115+ C# classes from the core BlinkID AAR

## BlinkID for iOS
Xamarin-iOS:  
[![NuGet Version](https://img.shields.io/nuget/v/Omnicasa.Mobile.BlinkID.iOS.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.iOS/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Omnicasa.Mobile.BlinkID.iOS.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.iOS/)

Net8-iOS:  
[![NuGet Version](https://img.shields.io/nuget/v/Omnicasa.Mobile.BlinkID.Maui.iOS.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.iOS/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Omnicasa.Mobile.BlinkID.Maui.iOS.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.iOS/)


---

## BlinkID for Droid
Xamarin-Droid:  
[![NuGet Version](https://img.shields.io/nuget/v/Omnicasa.Mobile.BlinkID.Droid.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Droid/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Omnicasa.Mobile.BlinkID.Droid.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Droid/)

Net8-Droid:  
[![NuGet Version](https://img.shields.io/nuget/v/Omnicasa.Mobile.BlinkID.Maui.Droid.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Droid/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Omnicasa.Mobile.BlinkID.Maui.Droid.svg)](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Droid/)

---

## NuGet

| Category | Package |
|---------|---------|
| **Binding** | |
|  | [Omnicasa.Mobile.BlinkID.iOS](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.iOS/) |
|  | [Omnicasa.Mobile.BlinkID.Droid](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Droid/) |
|  | [Omnicasa.Mobile.BlinkID.Maui.iOS](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.iOS/) |
|  | [Omnicasa.Mobile.BlinkID.Maui.Droid](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Droid/) |
| **Shared – Xamarin** | |
|  | [Omnicasa.Mobile.BlinkID.Shared](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Shared/) |
|  | [Omnicasa.Mobile.BlinkID.Shared.iOS](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Shared.iOS/) |
|  | [Omnicasa.Mobile.BlinkID.Shared.Droid](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Shared.Droid/) |
| **Shared – .NET 8** | |
|  | [Omnicasa.Mobile.BlinkID.Maui.Shared](https://www.nuget.org/packages/Omnicasa.Mobile.BlinkID.Maui.Shared/) |



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
