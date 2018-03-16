// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Classic.IOS.Views
{
    [Register ("HomeView")]
    partial class HomeView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView myActivityIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView myBackgroundView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView myTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (myActivityIndicator != null) {
                myActivityIndicator.Dispose ();
                myActivityIndicator = null;
            }

            if (myBackgroundView != null) {
                myBackgroundView.Dispose ();
                myBackgroundView = null;
            }

            if (myTableView != null) {
                myTableView.Dispose ();
                myTableView = null;
            }
        }
    }
}