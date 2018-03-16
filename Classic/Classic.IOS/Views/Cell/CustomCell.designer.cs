// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Classic.IOS.Views.Cell
{
    [Register ("CustomCell")]
    partial class CustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel descriptionLBL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel titleLBL { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (descriptionLBL != null) {
                descriptionLBL.Dispose ();
                descriptionLBL = null;
            }

            if (titleLBL != null) {
                titleLBL.Dispose ();
                titleLBL = null;
            }
        }
    }
}