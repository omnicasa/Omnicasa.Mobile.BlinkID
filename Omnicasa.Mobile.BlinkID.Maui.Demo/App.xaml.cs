using CommonServiceLocator;
using Unity;
using Unity.ServiceLocation;

namespace Omnicasa.Mobile.BlinkID.Maui.Demo;

public partial class App : Application
{
    /// <summary>Gets unityContainer.</summary>
    public static UnityContainer Container { get; } = new UnityContainer();

    public App()
	{
		InitializeComponent();

        var unityServiceLocator = new UnityServiceLocator(Container);
        ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

        MainPage = new AppShell();
	}
}

