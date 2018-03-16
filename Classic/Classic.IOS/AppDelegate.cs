
using MvvmCross.Platform;
using Foundation;
using UIKit;
using MvvmCross.Platform.Ios.Core;
using MvvmCross.ViewModels;
using MvvmCross;

namespace Classic.IOS
{


    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, Window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            return true;
        }
    }

}


