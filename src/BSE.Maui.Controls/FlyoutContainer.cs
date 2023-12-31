using System.Collections.ObjectModel;

namespace BSE.Maui.Controls
{
    [ContentProperty(nameof(MenuItems))]
    public partial class FlyoutContainer : FlyoutPage
    {
        private readonly ObservableCollection<FlyoutMenuItem> _menuItems;

        public static readonly BindableProperty BottomViewProperty =
            BindableProperty.CreateAttached(nameof(BottomView),
                typeof(ContentView),
                typeof(FlyoutContainer),
                null);

        public virtual ContentView BottomView
        {
            get
            {
                return (ContentView)GetValue(BottomViewProperty);
            }
            set
            {
                SetValue(BottomViewProperty, value);
            }
        }

        public IList<FlyoutMenuItem> MenuItems
        {
            get { return _menuItems; }
        }

        public FlyoutContainer()
        {
            _menuItems = new ObservableCollection<FlyoutMenuItem>();
        }

        protected override void OnParentSet()
        {
            /*
             * prevents InvalidOperationException("Flyout and Detail must be set before adding FlyoutPage to a container")
             */
            //base.OnParentSet();
        }
    }
}

