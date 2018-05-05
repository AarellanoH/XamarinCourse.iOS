using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Todolist
{
    public class TaskDataSource : UITableViewSource
    {
        string strCellId = "CellId";
        private UIViewController owner;
        private List<TaskModel> lstTasksToShow;

        public TaskDataSource(UIViewController owner, EnumTasksFilter enumTasksFilter)
        {
            this.owner = owner;
            this.lstTasksToShow = new List<TaskModel>();

            //Revisar todas las tasks del DAO para realizar el filtrado
            foreach(TaskModel task in TaskDAO.lstTasks)
            {
                /*CASE*/
                if (enumTasksFilter == EnumTasksFilter.All)
                {
                    this.lstTasksToShow.Add(task);
                }
                else if (enumTasksFilter == EnumTasksFilter.ToDo)
                {
                    if (task.intPercentage == 0)
                    {
                        this.lstTasksToShow.Add(task);
                    }
                }
                else if (enumTasksFilter == EnumTasksFilter.Doing)
                {
                    if (task.intPercentage > 0 &&
                        task.intPercentage < 100)
                    {
                        this.lstTasksToShow.Add(task);
                    }
                }
                else if (enumTasksFilter == EnumTasksFilter.Done)
                {
                    if (task.boolDone)
                    {
                        this.lstTasksToShow.Add(task);
                    }
                }
                /*END-CASE*/
            }
        }


        #region Implementacion metodos TableViewSource
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //Obtener la celda reusable
            UITableViewCell cell = tableView.DequeueReusableCell(this.strCellId);

            //Obtener la task de acuerdo al row en el que se encuentra la table
            TaskModel task = this.lstTasksToShow[indexPath.Row];

            //Desplegar el titulo de la task en la celda
            cell.TextLabel.Text = task.strTitle;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this.lstTasksToShow.Count;
        }

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            //Sacar task de la lista calculada
            TaskModel task = this.lstTasksToShow[indexPath.Row];

            //Navegar al TaskForm asignando un task para editar
            TaskFormViewController taskFormVC =
                this.owner.Storyboard.InstantiateViewController("TaskFormViewController")
                    as TaskFormViewController;
            taskFormVC.task = task;
            this.owner.NavigationController.PushViewController(taskFormVC, true);
		}

		#endregion
	}

    public enum EnumTasksFilter
    {
        All,
        ToDo,
        Doing,
        Done
    }
}
