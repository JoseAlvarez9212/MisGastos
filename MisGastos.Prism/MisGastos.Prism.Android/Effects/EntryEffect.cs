using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Views.Animations;
using Android.Widget;
using MisGastos.Prism.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.PlatformConfiguration;

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

            //var hintTextTransition = AnimationUtils.LoadAnimation(Android.App.Application.Context,Android.Resource.Animation.SlideOutRight);

            //pEntry.StartAnimation(hintTextTransition);
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

