using System;
using Classic.Core.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.Ios.Views;
using UIKit;

namespace Classic.IOS.Views
{
    public partial class AboutView : MvxViewController
    {

        private String imgBigUrl;
        public String ImgBigUrl{
            get{
                return this.imgBigUrl;
            }
            set{
                this.imgBigUrl = value;
                using (var imgUrl = new NSUrl(this.imgBigUrl))
                {
                    using (var data = NSData.FromUrl(imgUrl))
                    {
                        this.myImageView.Image = UIImage.LoadFromData(data);
                    }
                }

            }
        }

        private String titleVC;
        public String TitleVC{
            get{
                return this.titleVC;
            }
            set{
                this.titleVC = value;
                this.myTitleLBL.Text = this.titleVC;
            }
        }

        public AboutView() : base("AboutView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.SetBindings();
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);
            this.Title = this.titleVC;
		}



		private void SetBindings()
        {
            var set = this.CreateBindingSet<AboutView, AboutViewModel>();

            set.Bind(this.myVotesLBL)
               .For(s => s.Text)
               .To(vm => vm.SelectedMovie.VoteCount);

            set.Bind(this.myIdLBL)
               .For(s => s.Text)
               .To(vm => vm.SelectedMovie.Id);

            set.Bind(this)
               .For(s => s.TitleVC)
               .To(vm => vm.Title);

            set.Bind(this.myOriginalTitleLBL)
               .For(s => s.Text)
               .To(vm => vm.SelectedMovie.OriginalTitle);

            set.Bind(this.myOriginalLanguageLBL)
               .For(s => s.Text)
               .To(vm => vm.SelectedMovie.OriginalLanguage);

            set.Bind(this)
               .For(s => s.ImgBigUrl)
               .To(vm => vm.SelectedMovie.ImgBig);


            set.Apply();
        }
    }
}

