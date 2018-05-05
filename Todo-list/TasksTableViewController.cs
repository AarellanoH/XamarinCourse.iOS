using Foundation;
using System;
using UIKit;

namespace Todolist
{
    public partial class TasksTableViewController : UIViewController
    {
        public EnumTasksFilter enumTasksFilter;

        public TasksTableViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Decirle a la tabla de donde sacara la info a desplegar
            this.tvTasks.Source = new TaskDataSource(this, this.enumTasksFilter);
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);

            //Refresh table
            this.tvTasks.Source = new TaskDataSource(this, this.enumTasksFilter);
            this.tvTasks.ReloadData();
		}
	}
}