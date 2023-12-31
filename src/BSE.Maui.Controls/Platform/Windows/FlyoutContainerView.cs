using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace BSE.Maui.Controls.Platform
{
    public partial class FlyoutContainerView : NavigationView
    {
        internal FlyoutContainer Element { get; set; }
        internal NavigationView? NavigationView;
        internal Microsoft.UI.Xaml.Controls.Grid? BottomView;
        internal event EventHandler? OnApplyTemplateFinished;
        ObservableCollection<object> FlyoutItems = new ObservableCollection<object>();

        public virtual FlyoutTemplateSelector CreateFlyoutTemplateSelector() => new FlyoutTemplateSelector();

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            NavigationView = GetTemplateChild("NavigationView") as NavigationView;
            BottomView = GetTemplateChild("BottomView") as Microsoft.UI.Xaml.Controls.Grid;

            if (NavigationView != null)
            {
                NavigationView.OpenPaneLength = 320;
                NavigationView.IsSettingsVisible = false;
                NavigationView.MenuItemsSource = FlyoutItems;
                NavigationView.MenuItemTemplateSelector = CreateFlyoutTemplateSelector();
            }

            OnApplyTemplateFinished?.Invoke(this, EventArgs.Empty);

        }

        internal void SetElement(VisualElement element)
        {
            if (Element != null && element != null)
            {
                throw new NotSupportedException("Reuse of the FlyoutContainer Renderer is not supported");
            }

            Element = (FlyoutContainer)element;
        }

        internal void UpdateMenuItemSource()
        {
            var menuItems = Element.MenuItems;
            if (menuItems != null)
            {
                var newItems = IterateItems(menuItems).ToList();

                foreach (var item in newItems)
                {
                    if (!FlyoutItems.Contains(item))
                    {
                        FlyoutItems.Add(item);
                    }
                }

                for (var i = FlyoutItems.Count - 1; i >= 0; i--)
                {
                    var item = FlyoutItems[i];
                    if (!newItems.Contains(item))
                        FlyoutItems.RemoveAt(i);
                }
            }
        }

        IEnumerable<object> IterateItems(IList<FlyoutMenuItem> items)
        {
            foreach (var item in items)
            {
                bool foundExistingVM = false;

                // Check to see if this element already has a VM counter part
                foreach (var navItem in FlyoutItems)
                {
                    if (navItem is NavigationViewItemViewModel viewModel && viewModel.Data == item)
                    {
                        foundExistingVM = true;
                        yield return viewModel;
                    }
                }

                if (!foundExistingVM)
                {
                    yield return new NavigationViewItemViewModel()
                    {
                        Data = item
                    };
                }
            }
        }
    }
}
