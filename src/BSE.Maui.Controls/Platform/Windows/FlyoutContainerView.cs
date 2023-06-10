using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml.Controls;

namespace BSE.Maui.Controls.Platform
{
    public partial class FlyoutContainerView : NavigationView
    {
        internal NavigationView? NavigationView;
        internal Microsoft.UI.Xaml.Controls.Grid? BottomView;

        internal event EventHandler? OnApplyTemplateFinished;


        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            NavigationView = GetTemplateChild("NavigationView") as NavigationView;
            BottomView = GetTemplateChild("BottomView") as Microsoft.UI.Xaml.Controls.Grid;

            if (NavigationView != null)
            {
                NavigationView.OpenPaneLength = 320;
                //NavigationView.MenuItemsSource = FlyoutItems;
                //NavigationView.MenuItemTemplateSelector = CreateShellFlyoutTemplateSelector();
            }

            OnApplyTemplateFinished?.Invoke(this, EventArgs.Empty);

        }
    }
}
