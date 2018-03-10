using Android.Content;
using MvvmCross.Platform.Android.Presenters;
using MvvmCross.ViewModels;
using Classic.Core;
using MvvmCross.Platform.Android.Core;

namespace Classic.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

   
        
    }
}