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
        UIKit.UIButton btnNew { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tvTasks { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnNew != null) {
                btnNew.Dispose ();
                btnNew = null;
            }

            if (tvTasks != null) {
                tvTasks.Dispose ();
                tvTasks = null;
            }
        }
    }
}