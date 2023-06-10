#if WINDOWS
using BSE.Maui.Controls;
using BSE.Maui.Controls.Handlers;
using BSE.Maui.Controls.Platform.Windows;
using Microsoft.Extensions.DependencyInjection.Extensions;
#endif
namespace BSE.Maui.Controls
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseBSEControls(this MauiAppBuilder builder)
        {
#if WINDOWS
            builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IMauiInitializeService, BSEControlsInitializer>());
#endif

            builder.ConfigureMauiHandlers(handlers =>
            {
#if WINDOWS
                handlers.AddHandler(typeof(FlyoutContainer), typeof(FlyoutContainerHandler));

#endif
            });
            return builder;
        }


        class BSEControlsInitializer : IMauiInitializeService
        {
            public void Initialize(IServiceProvider services)
            {
#if WINDOWS
                var dispatcher =
                    services.GetService<IDispatcher>() ??
                    MauiWinUIApplication.Current.Services.GetRequiredService<IDispatcher>();

                //if (dispatcher.IsDispatchRequired)
                {
                    dispatcher.DispatchAsync(() =>
                    {
                        try
                        {
                            var dictionaries = Microsoft.UI.Xaml.Application.Current?.Resources?.MergedDictionaries;
                            if (dictionaries != null)
                            {
                                Microsoft.UI.Xaml.Application.Current?.Resources?.AddLibraryResources("BSEControlsIncluded", "ms-appx:///BSE.Maui.Controls/Platform/Windows/Resources.xaml");
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    });
                }
#endif
            }
        }
    }
}
