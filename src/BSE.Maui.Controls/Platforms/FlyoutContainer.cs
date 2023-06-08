using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls

namespace BSE.Maui.Controls
{
    public partial class FlyoutContainer : FlyoutPage
    { 

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
}

