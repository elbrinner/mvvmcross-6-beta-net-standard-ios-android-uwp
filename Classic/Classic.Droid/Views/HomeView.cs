using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Classic.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.Android.Presenters.Attributes;
using MvvmCross.Platform.Android.Views;

namespace Classic.Droid.Views
{

    [MvxActivityPresentation]
    [Activity(MainLauncher = true)]
    public class HomeView : MvxActivity<HomeViewModel>
    {
        private bool visible;
        ProgressBar progress;

        public bool Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
                if (value)
                {
                    progress.Visibility = ViewStates.Visible;
                }else{
                    progress.Visibility = ViewStates.Invisible;
                }
            }
        }
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);

            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            progress = this.FindViewById<ProgressBar>(Resource.Id.progressBarElement);
            set.Bind(this).For(p => p.Visible).To(vm => vm.IsBusy);
            set.Apply();

        }


    }
}