using Microsoft.UI.Xaml;

namespace BSE.Maui.Controls.Platform
{
    public class FlyoutTemplateSelector : Microsoft.UI.Xaml.Controls.DataTemplateSelector
    {
        Microsoft.UI.Xaml.DataTemplate BaseShellItemTemplate { get; }
        Microsoft.UI.Xaml.DataTemplate MenuItemTemplate { get; }

        public FlyoutTemplateSelector()
        {
            BaseShellItemTemplate = (Microsoft.UI.Xaml.DataTemplate)Microsoft.UI.Xaml.Application.Current.Resources["FlyoutBaseItemTemplate"];
            MenuItemTemplate = (Microsoft.UI.Xaml.DataTemplate)Microsoft.UI.Xaml.Application.Current.Resources["FlyoutMenuItemTemplate"];
        }

        protected override Microsoft.UI.Xaml.DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }

        protected override Microsoft.UI.Xaml.DataTemplate SelectTemplateCore(object item)
        {
            if (item is MenuItem)
                return MenuItemTemplate;

            if (item is NavigationViewItemViewModel nvm && nvm.Data is MenuItem)
                return MenuItemTemplate;

            return BaseShellItemTemplate;
        }
    }
}
