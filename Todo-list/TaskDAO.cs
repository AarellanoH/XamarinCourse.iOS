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

        //Editar task existente
        public static void editTask(TaskModel task)
        {
            //La posicion en la que esta en la lista el task
            int intIndex = TaskDAO.lstTasks.FindIndex(foundTask => foundTask.intId == task.intId);
            TaskDAO.lstTasks[intIndex] = task;
        }

        //Borrar task existente
        public static void deleteTask(TaskModel task)
        {
            TaskDAO.lstTasks.Remove(task);
        }
    }
}
