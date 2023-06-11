#nullable disable
#if WINDOWS || TIZEN
using System;
using System.Collections.Generic;
using System.Text;
using BSE.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;

using FlyoutCont = BSE.Maui.Controls.FlyoutContainer;

namespace BSE.Maui.Controls.Handlers
{
    public partial class FlyoutContainerHandler
    {
        public static PropertyMapper<FlyoutCont, FlyoutContainerHandler> Mapper =
            new PropertyMapper<FlyoutCont, FlyoutContainerHandler>(ElementMapper)
            {
#if ANDROID || WINDOWS || TIZEN
                [nameof(IFlyoutView.Flyout)] = MapFlyout,
                [nameof(IFlyoutView.Detail)] = MapDetail,
                [nameof(FlyoutCont.BottomView)] = MapBottomView,
                //[nameof(IFlyoutView.IsPresented)] = MapIsPresented,
                //[nameof(IFlyoutView.FlyoutBehavior)] = MapFlyoutBehavior,
                [nameof(IFlyoutView.FlyoutWidth)] = MapFlyoutWidth,
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

        protected override void ConnectHandler(FlyoutContainerView platformView)
        {
            base.ConnectHandler(platformView);

            platformView.OnApplyTemplateFinished += OnApplyTemplateFinished;
        }

        private void OnApplyTemplateFinished(object sender, EventArgs e)
        {
            UpdateValue(nameof(FlyoutContainerView.BottomView));
            UpdateValue(nameof(FlyoutContainerView));
        }
    }
}
#endif