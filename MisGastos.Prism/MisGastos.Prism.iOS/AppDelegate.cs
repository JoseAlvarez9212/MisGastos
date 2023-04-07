﻿using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Foundation;
using MisGastos.Prism.iOS.Services.FirebaseServices;
using MisGastos.Prism.iOS.ViewControllers;
using MisGastos.Prism.Services.Firebase;
using Prism;
using Prism.Ioc;
using UIKit;


namespace MisGastos.Prism.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            if (Window is null)
            {
                Window = new UIWindow(frame:UIScreen.MainScreen.Bounds);
                var initViewController = new LaunchScreenViewController(options);
                Window.RootViewController = initViewController;
                Window.MakeKeyAndVisible();
                return true;
            }
            else
            {
                global::Xamarin.Forms.Forms.Init();
                CachedImageRenderer.Init();
                var ignore = typeof(SvgCachedImage);
                LoadApplication(new App(new iOSInitializer()));

                return base.FinishedLaunching(app, options);
            }
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.Register<IFirebaseAuthentication, FirebaseAuthentication>();
        }
    }
}
