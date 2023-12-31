#nullable disable
#if WINDOWS || TIZEN
using BSE.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using FlyoutCont = BSE.Maui.Controls.FlyoutContainer;

namespace BSE.Maui.Controls.Handlers
{
    public partial class FlyoutContainerHandler
    {
        public static PropertyMapper<FlyoutCont, FlyoutContainerHandler> Mapper =
            new PropertyMapper<FlyoutCont, FlyoutContainerHandler>(ElementMapper)
            {
#if ANDROID || WINDOWS || TIZEN
                //[nameof(IFlyoutView.Flyout)] = MapFlyout,
                [nameof(IFlyoutView.Detail)] = MapDetail,
                [nameof(FlyoutCont.BottomView)] = MapBottomView,
                [nameof(FlyoutCont.MenuItems)] = MapMenuItems,
                //[nameof(IFlyoutView.IsPresented)] = MapIsPresented,
                //[nameof(IFlyoutView.FlyoutBehavior)] = MapFlyoutBehavior,
                //[nameof(IFlyoutView.FlyoutWidth)] = MapFlyoutWidth,
                //[nameof(IFlyoutView.IsGestureEnabled)] = MapIsGestureEnabled,
                //[nameof(IToolbarElement.Toolbar)] = MapToolbar,
#endif
            };

        public static CommandMapper<FlyoutCont, FlyoutContainerHandler> CommandMapper =
            new CommandMapper<FlyoutCont, FlyoutContainerHandler>(ViewHandler.ElementCommandMapper);

        public FlyoutContainerHandler()
            : base(Mapper, CommandMapper)
        {
        }

    }
}
#endif