using System;
using Classic.Core.Models.Movie;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.Ios.Binding.Views;
using UIKit;

namespace Classic.IOS.Views.Cell
{
    public partial class CustomCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("CustomCell");
        public static readonly UINib Nib;

        static CustomCell()
        {
            Nib = UINib.FromName("CustomCell", NSBundle.MainBundle);
        }

        protected CustomCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            this.DelayBind(this.SetBindings);
        }


        /// <summary>
        /// Awakes from nib.
        /// </summary>
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.SelectionStyle = UITableViewCellSelectionStyle.None;
        }

        /// <summary>
        /// Sets the bindings.
        /// </summary>
        private void SetBindings()
        {
            var set = this.CreateBindingSet<CustomCell, ResultMovie>();

            set.Bind(this.titleLBL)
                .For(v => v.Text)
               .To(item => item.Title);

            set.Bind(this.descriptionLBL)
                .For(v => v.Text)
               .To(item => item.OriginalTitle);

            set.Apply();
        }
    }
}
