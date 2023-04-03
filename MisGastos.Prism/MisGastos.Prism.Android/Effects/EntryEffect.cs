using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Widget;
using MisGastos.Prism.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MGE")]
[assembly: ExportEffect(typeof(EntryEffect), nameof(EntryEffect))]
namespace MisGastos.Prism.Droid.Effects
{
    /// <summary>
    /// Entry effect android
    /// </summary>
    public class EntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var pEntry = Control as EditText;
            if (pEntry is null)
                return;

            pEntry.SetPadding(
                20,
                pEntry.PaddingTop,
                pEntry.PaddingRight,
                pEntry.PaddingBottom);
            pEntry.Background = GetBackgroundDrawable();
        }

        protected override void OnDetached()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Get background drawable.
        /// </summary>
        /// <returns>GradientDrawable</returns>
        private GradientDrawable GetBackgroundDrawable()
        {
            var border = new GradientDrawable();
            border.SetCornerRadius(10);
            border.SetStroke(1, ColorStateList.ValueOf(Android.Graphics.Color.LightSlateGray));
            return border;
        }
    }
}

