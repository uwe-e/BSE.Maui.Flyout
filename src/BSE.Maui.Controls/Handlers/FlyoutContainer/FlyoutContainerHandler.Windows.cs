﻿#if WINDOWS

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

namespace BSE.Maui.Controls.Handlers
{
    public partial class FlyoutContainerHandler : ViewHandler<FlyoutContainer, FlyoutContainerView>
	{
        protected override FlyoutContainerView CreatePlatformView()
        {
            var flyoutView = new FlyoutContainerView();
            return flyoutView;
        }

        public static void MapFlyout(FlyoutContainerHandler handler, IFlyoutView container)
        {

        }

        public static void MapFlyoutWidth(FlyoutContainerHandler handler, FlyoutContainer container)
        {
            if (container.Width >= 0)
            {

            }
        }

        public static void MapDetail(FlyoutContainerHandler handler, IFlyoutView flyoutView)
		{
			UpdateDetail(handler);
		}

        public static void MapBottomView(FlyoutContainerHandler handler, FlyoutContainer container)
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
            _ = handler.MauiContext;
            _ = handler.VirtualView.Detail.ToPlatform(handler.MauiContext);

            //handler.PlatformView.Content = handler.VirtualView.Detail.ToPlatform();
        }
    }
}

#endif