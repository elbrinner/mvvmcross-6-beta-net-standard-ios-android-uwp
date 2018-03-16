// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Classic.IOS.Views
{
    [Register ("AboutView")]
    partial class AboutView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel myIdLBL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView myImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel myOriginalLanguageLBL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel myOriginalTitleLBL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel myTitleLBL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel myVotesLBL { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (myIdLBL != null) {
                myIdLBL.Dispose ();
                myIdLBL = null;
            }

            if (myImageView != null) {
                myImageView.Dispose ();
                myImageView = null;
            }

            if (myOriginalLanguageLBL != null) {
                myOriginalLanguageLBL.Dispose ();
                myOriginalLanguageLBL = null;
            }

            if (myOriginalTitleLBL != null) {
                myOriginalTitleLBL.Dispose ();
                myOriginalTitleLBL = null;
            }

            if (myTitleLBL != null) {
                myTitleLBL.Dispose ();
                myTitleLBL = null;
            }

            if (myVotesLBL != null) {
                myVotesLBL.Dispose ();
                myVotesLBL = null;
            }
        }
    }
}