using Microsoft.Maui.Handlers;
#if WINDOWS
using PlatformView = BSE.Maui.Controls.Platform.FlyoutContainerView;
#else
using PlatformView = System.Object;
#endif

namespace BSE.Maui.Controls.Handlers.FlyoutContainer
{
    public interface IFlyoutContainerHandler : IViewHandler
    {
        new IFlyoutView VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}
