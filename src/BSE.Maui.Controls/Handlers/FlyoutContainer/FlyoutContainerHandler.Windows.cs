#if WINDOWS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSE.Maui.Controls;
using BSE.Maui.Controls.Platform;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml.Controls;
using FlyoutCont = BSE.Maui.Controls.FlyoutContainer;

namespace BSE.Maui.Controls.Handlers
{
    public partial class FlyoutContainerHandler : ViewHandler<FlyoutCont, FlyoutContainerView>
    {
        protected override FlyoutContainerView CreatePlatformView()
        {
            var flyoutView = new FlyoutContainerView();
            return flyoutView;
        }

        public static void MapFlyout(FlyoutContainerHandler handler, IFlyoutView container)
        {
            var t1 = handler.MauiContext;
            var t2 = handler.VirtualView.Flyout.ToPlatform(handler.MauiContext);

            if (handler.PlatformView is FlyoutContainerView rnv)
            {
                if (rnv.NavigationView != null)
                {
                    rnv.NavigationView.PaneCustomContent = handler.VirtualView.Flyout.ToPlatform(handler.MauiContext);
                }

            }
        }

        public static void MapFlyoutWidth(FlyoutContainerHandler handler, FlyoutCont container)
        {
            if (container.Width >= 0)
            {

            }
        }

        public static void MapDetail(FlyoutContainerHandler handler, IFlyoutView flyoutView)
        {
            UpdateDetail(handler);
        }

        public static void MapBottomView(FlyoutContainerHandler handler, FlyoutCont container)
        {
            if (handler.PlatformView is FlyoutContainerView flyoutContainerView)
            {
                var contentControl = container.BottomView;
                var frameworkElement = contentControl.ToPlatform(handler.MauiContext);

                if (flyoutContainerView.BottomView is Microsoft.UI.Xaml.Controls.Grid bottomView)
                {
                    bottomView.Children.Add(frameworkElement);
                }
            }
        }

        private static void UpdateDetail(FlyoutContainerHandler handler)
        {
            if (handler.PlatformView.NavigationView is NavigationView navigationView)
            {
                navigationView.Content = handler.VirtualView.Detail.ToPlatform(handler.MauiContext);
            }
        }
    }
}

#endif