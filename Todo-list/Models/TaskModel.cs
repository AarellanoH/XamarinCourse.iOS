using System;
namespace Todolist
{
    public class TaskModel
    {
        public int intId { get; set; }
        public string strTitle { get; set; }
        public string strDescription { get; set; }

        public TaskModel()
        {
        }

        public TaskModel(string strTitle, string strDescription)
        {
            this.strTitle = strTitle;
            this.strDescription = strDescription;
        }

		public override string ToString()
		{
            return "Title: " + this.strTitle + ", Description: " + this.strDescription;
		}
	}
}
