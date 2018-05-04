using System;
using Foundation;
using UIKit;

namespace Todolist
{
    public class TaskDataSource : UITableViewSource
    {
        string strCellId = "CellId";

        public TaskDataSource()
        {
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
        #endregion
    }
}
