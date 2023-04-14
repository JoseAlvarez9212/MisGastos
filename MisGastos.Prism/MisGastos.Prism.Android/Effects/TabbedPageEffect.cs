using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using MisGastos.Prism.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(TabbedPageEffect), nameof(TabbedPageEffect))]
namespace MisGastos.Prism.Droid.Effects
{
    public class TabbedPageEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!(Container.GetChildAt(0) is ViewGroup layout))
                return;

            if (!(layout.GetChildAt(1) is BottomNavigationView bottomNavigationView))
                return;

            //bottomNavigationView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilitySelected;
        }

        protected override void OnDetached()
        {
            //throw new NotImplementedException();
        }
    }
}

