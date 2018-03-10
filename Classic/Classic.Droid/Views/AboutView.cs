using System;
using Android.App;
using Android.OS;
using Classic.Core.ViewModels;
using MvvmCross.Platform.Android.Views;

namespace Classic.Droid.Views
{
    [Activity]
    public class AboutView : MvxActivity<AboutViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AboutView);
        }
    }
}
