using System;
using System.Collections.Generic;

namespace Todolist
{
    public class TaskDAO
    {
        //Lista de tasks que estan guardadas
        public static List<TaskModel> lstTasks { get; set; }
        private static int intIndex { get; set;}

        static TaskDAO()
        {
            TaskDAO.lstTasks = new List<TaskModel>();
            TaskDAO.intIndex = 1;
        }

        public TaskDAO()
        {
        }

        //Anadir un nuevo task
        public static void addTask(TaskModel task)
        {
            int intId = TaskDAO.intIndex;
            task.intId = intId;
            TaskDAO.lstTasks.Add(task);
            TaskDAO.intIndex = TaskDAO.intIndex + 1;
        }
    }
}
