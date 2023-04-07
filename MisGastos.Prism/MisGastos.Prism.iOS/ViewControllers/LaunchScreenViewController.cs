using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Airbnb.Lottie;
using CoreGraphics;
using FFImageLoading;
using FFImageLoading.Svg.Platform;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace MisGastos.Prism.iOS.ViewControllers
{
	public partial class LaunchScreenViewController : UIViewController
	{
        private UIImageView ImgLogoApp;
        private LOTAnimationView LottieSplash;
        private NSDictionary LaunchOptions;

        public LaunchScreenViewController () : base ("LaunchScreenViewController", null)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchViewController"/> class.
        /// </summary>
        public LaunchScreenViewController(NSDictionary launchOptions)
        {
            LaunchOptions = launchOptions ?? new NSDictionary();
        }

        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            //Logo App
            //View.BackgroundColor = UIColor.FromRGB(79, 10, 58);

            var containerView = new UIView();
            containerView.BackgroundColor = UIColor.FromRGB(79, 10, 58);
            containerView.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(containerView);

            containerView.TopAnchor.ConstraintEqualTo(this.View.TopAnchor).Active = true;
            containerView.LeadingAnchor.ConstraintEqualTo(this.View.LeadingAnchor).Active = true;
            containerView.TrailingAnchor.ConstraintEqualTo(this.View.TrailingAnchor).Active = true;
            containerView.BottomAnchor.ConstraintEqualTo(this.View.BottomAnchor).Active = true;

            UIImageView ImgLogoApp = new UIImageView();
            ImgLogoApp.TranslatesAutoresizingMaskIntoConstraints = false;

            //Animation Loading
            LottieSplash = LOTAnimationView.AnimationNamed("lottie_loading");
            LottieSplash.TranslatesAutoresizingMaskIntoConstraints = false;

            containerView.AddSubviews(ImgLogoApp, LottieSplash);

            ImgLogoApp.CenterXAnchor.ConstraintEqualTo(containerView.CenterXAnchor).Active = true;
            ImgLogoApp.CenterYAnchor.ConstraintEqualTo(containerView.CenterYAnchor).Active = true;
            ImgLogoApp.WidthAnchor.ConstraintEqualTo(200).Active = true;
            ImgLogoApp.HeightAnchor.ConstraintEqualTo(100).Active = true;

            ImageService.Instance
                .LoadFileFromApplicationBundle("ic_app_name.svg")
                .WithCustomDataResolver(new SvgDataResolver(200, 150, true))
                .Into(ImgLogoApp);

            LottieSplash.TopAnchor.ConstraintEqualTo(ImgLogoApp.TopAnchor, 50).Active = true;
            LottieSplash.CenterXAnchor.ConstraintEqualTo(containerView.CenterXAnchor).Active = true;
            LottieSplash.WidthAnchor.ConstraintEqualTo(150).Active = true;
            LottieSplash.HeightAnchor.ConstraintEqualTo(150).Active = true;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            LottieSplash.PlayWithCompletion((animation) =>
            {
                UIApplication.SharedApplication.Delegate.FinishedLaunching(UIApplication.SharedApplication, LaunchOptions);
            });
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
			LottieSplash.Pause();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
    }
}


