using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Com.Airbnb.Lottie;
using FFImageLoading;
using FFImageLoading.Svg.Platform;

namespace MisGastos.Prism.Droid.Activities
{
    /// <summary>
    /// Splash screen Activity
    /// </summary>
    [Activity(Theme = "@style/MainTheme.SplashExpenses",
              ScreenOrientation = ScreenOrientation.Portrait,
              MainLauncher = true,
              NoHistory = true,
              Label = "SplashScreenActivity")]
    public class SplashScreenActivity : Activity, Animator.IAnimatorListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_spash_screen);

            var imageView = FindViewById<ImageView>(Resource.Id.imageView);
            ImageService.Instance
                .LoadFileFromApplicationBundle("ic_app_name.svg")
                .WithCustomDataResolver(new SvgDataResolver(200, 100, true))
                .Into(imageView);
            FindViewById<LottieAnimationView>(Resource.Id.animationLottieAnimationView).AddAnimatorListener(this);
        }

        #region IAnimatorListener

        /// <summary>
        /// Call when the animation is canceled
        /// </summary>
        /// <param name="animation">Animator</param>
        public void OnAnimationCancel(Animator animation)
        {
            //Nothing, but it is necessary for the Animator.IAnimatorListener.
        }

        /// <summary>
        /// Call when the animation ends
        /// </summary>
        /// <param name="animation">Animator</param>
        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        /// <summary>
        /// Call when the animation repeats
        /// </summary>
        /// <param name="animation">Animator</param>
        public void OnAnimationRepeat(Animator animation)
        {
            //Nothing, but it is necessary for the Animator.IAnimatorListener.
        }

        /// <summary>
        /// Call when the animation starts
        /// </summary>
        /// <param name="animation">Animator</param>
        public void OnAnimationStart(Animator animation)
        {
            //Nothing, but it is necessary for the Animator.IAnimatorListener.
        }
        #endregion
    }
}

