using System;

using UIKit;

namespace Todolist
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.tvTasks.Source = new TaskDataSource(this);

            //Funcionalidad boton new task, te lleva a la otra pantalla
            this.btnNew.TouchUpInside += delegate 
            {
                //Instanciar Task Form ViewController
                TaskFormViewController taskFormVC =
                    this.Storyboard.InstantiateViewController
                        ("TaskFormViewController") as TaskFormViewController;
                this.NavigationController.PushViewController(taskFormVC, true);
            };
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);
            this.tvTasks.ReloadData();
		}

	}
}
