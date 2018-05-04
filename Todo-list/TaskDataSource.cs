using System;
using Foundation;
using UIKit;

namespace Todolist
{
    public class TaskDataSource : UITableViewSource
    {
        string strCellId = "CellId";
        private UIViewController owner;

        public TaskDataSource(UIViewController owner)
        {
            this.owner = owner;
        }


        #region Implementacion metodos TableViewSource
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //Obtener la celda reusable
            UITableViewCell cell = tableView.DequeueReusableCell(this.strCellId);

            //Obtener la task de acuerdo al row en el que se encuentra la table
            TaskModel task = TaskDAO.lstTasks[indexPath.Row];

            //Desplegar el titulo de la task en la celda
            cell.TextLabel.Text = task.strTitle;

            return cell;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TaskDAO.lstTasks.Count;
        }

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            //Sacar task de la lista del DAO
            TaskModel task = TaskDAO.lstTasks[indexPath.Row];

            //Navegar al TaskForm asignando un task para editar
            TaskFormViewController taskFormVC =
                this.owner.Storyboard.InstantiateViewController("TaskFormViewController")
                    as TaskFormViewController;
            taskFormVC.task = task;
            this.owner.NavigationController.PushViewController(taskFormVC, true);
		}

		#endregion
	}
}
