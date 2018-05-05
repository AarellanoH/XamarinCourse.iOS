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

            //Funcionalidad boton new task, te lleva a la otra pantalla
            this.btnNew.TouchUpInside += delegate 
            {
                //Instanciar Task Form ViewController
                TaskFormViewController taskFormVC =
                    this.Storyboard.InstantiateViewController
                        ("TaskFormViewController") as TaskFormViewController;
                this.NavigationController.PushViewController(taskFormVC, true);
            };

            this.btnAll.TouchUpInside += delegate 
            {
                //Instanciar 4 TasksTable, uno para all, otro para ToDo, otro para Doing
                //      y otro para Done
                TasksTableViewController tasksTableAll =
                    this.Storyboard.InstantiateViewController("TasksTableViewController")
                        as TasksTableViewController;
                TasksTableViewController tasksTableToDo =
                    this.Storyboard.InstantiateViewController("TasksTableViewController")
                        as TasksTableViewController;
                TasksTableViewController tasksTableDoing =
                    this.Storyboard.InstantiateViewController("TasksTableViewController")
                        as TasksTableViewController;
                TasksTableViewController tasksTableDone =
                    this.Storyboard.InstantiateViewController("TasksTableViewController")
                        as TasksTableViewController;

                //Decirle a cada TasksTableViewController que es lo que debe de mostrar
                tasksTableAll.enumTasksFilter = EnumTasksFilter.All;
                tasksTableToDo.enumTasksFilter = EnumTasksFilter.ToDo;
                tasksTableDoing.enumTasksFilter = EnumTasksFilter.Doing;
                tasksTableDone.enumTasksFilter = EnumTasksFilter.Done;

                //Poner titulos a cada TaskBarViewController para que se muestre de titulo en el tab
                tasksTableAll.Title = "All";
                tasksTableToDo.Title = "To do";
                tasksTableDoing.Title = "Doing";
                tasksTableDone.Title = "Done";

                //Instanciar un Controller con navegacion de tabs y meter los controladores construidos
                UITabBarController tabBarController = new UITabBarController();
                tabBarController.AddChildViewController(tasksTableAll);
                tabBarController.AddChildViewController(tasksTableToDo);
                tabBarController.AddChildViewController(tasksTableDoing);
                tabBarController.AddChildViewController(tasksTableDone);

                //Navegar hacia el tabBarController
                this.NavigationController.PushViewController(tabBarController, true);
            };
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);

            int intTasksToDo = 0;
            int intTasksDoing = 0;
            int intTasksDone = 0;

            //Revisar todas las tasks del DAO para realizar el filtrado
            foreach (TaskModel task in TaskDAO.lstTasks)
            {
                /*CASE*/
                if (task.intPercentage == 0)
                {
                    intTasksToDo = intTasksToDo + 1;
                }
                else if (task.intPercentage > 0 &&
                        task.intPercentage < 100)
                {
                    intTasksDoing = intTasksDoing + 1;
                }
                else if (task.boolDone)
                {
                    intTasksDone = intTasksDone + 1;
                }
                /*END-CASE*/
            }

            //Desplegar 
            this.lblTasksTodo.Text = intTasksToDo + " Tasks to do";
            this.lblTasksDoing.Text = intTasksDoing + " Tasks doing";
            this.lblTasksDone.Text = intTasksDone + " Tasks done";

		}

	}
}
