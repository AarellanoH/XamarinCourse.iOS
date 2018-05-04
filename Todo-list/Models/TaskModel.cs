using System;
namespace Todolist
{
    public class TaskModel
    {
        public int intId { get; set; }
        public string strTitle { get; set; }
        public string strDescription { get; set; }
        public bool boolDone { get; set; }
        public int intPercentage { get; set; }

        public TaskModel()
        {
        }

		public TaskModel(string strTitle, string strDescription, bool boolDone, int intPercentage)
        {
            this.strTitle = strTitle;
            this.strDescription = strDescription;
            this.boolDone = boolDone;
            this.intPercentage = intPercentage;
        }

        public override string ToString()
		{
            return "Title: " + this.strTitle + ", Description: " + this.strDescription;
		}
	}
}
