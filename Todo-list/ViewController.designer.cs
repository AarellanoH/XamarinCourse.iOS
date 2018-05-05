// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Todolist
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAll { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnNew { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTasksDoing { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTasksDone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTasksTodo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAll != null) {
                btnAll.Dispose ();
                btnAll = null;
            }

            if (btnNew != null) {
                btnNew.Dispose ();
                btnNew = null;
            }

            if (lblTasksDoing != null) {
                lblTasksDoing.Dispose ();
                lblTasksDoing = null;
            }

            if (lblTasksDone != null) {
                lblTasksDone.Dispose ();
                lblTasksDone = null;
            }

            if (lblTasksTodo != null) {
                lblTasksTodo.Dispose ();
                lblTasksTodo = null;
            }
        }
    }
}