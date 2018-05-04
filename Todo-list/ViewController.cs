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


            this.tvTasks.Source = new TaskDataSource();

            //Imprimir en consola
            this.btnSave.TouchUpInside += (object sender, EventArgs e) => 
            {
                //Extraer el titulo y la descripcion
                string strTitle = this.tfTitle.Text;
                string strDescription = this.txvDescription.Text;

                //Construir task y guardarlo
                TaskModel task = new TaskModel(strTitle, strDescription);
                TaskDAO.addTask(task);

                //Limpiar los inputs
                this.tfTitle.Text = String.Empty;
                this.txvDescription.Text = String.Empty;

                //Actualizar la tabla
                this.tvTasks.ReloadData();
            };
        }

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);
		}

	}
}
