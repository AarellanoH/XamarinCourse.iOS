using Foundation;
using System;
using UIKit;

namespace Todolist
{
    public partial class TaskFormViewController : UIViewController
    {
        public TaskModel task;

        public TaskFormViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            bool boolEditMode;
            //Si se recibio task significa que se esta editando un task existente
            if (this.task != null)
            {
                boolEditMode = true;
                this.btnDelete.Hidden = false;
            }
            else
            {
                boolEditMode = false;
            }

            //Cargar datos en caso de que se este editando
            if (boolEditMode)
            {
                this.tfTitle.Text = task.strTitle;
                this.txvDescription.Text = task.strDescription;
                this.switchDone.SetState(this.task.boolDone, false);
                this.sliderPercentage.SetValue(this.task.intPercentage, false);
                this.lblPercentage.Text = this.task.intPercentage.ToString() + "%";
            }

            //Acciones de boton de save
            this.btnSave.TouchUpInside += delegate
            {
                //Extraer los datos del GUI
                string strTitle = this.tfTitle.Text;
                string strDescription = this.txvDescription.Text;
                bool boolDone = this.switchDone.On;
                int intPercentage = (int)this.sliderPercentage.Value;


                if (boolEditMode)
                {
                    //Actualizando valores del task que se nos envio
                    this.task.strTitle = strTitle;
                    this.task.strDescription = strDescription;
                    this.task.boolDone = boolDone;
                    this.task.intPercentage = intPercentage;

                    //Guardar cambios del task editado
                    TaskDAO.editTask(this.task);
                }
                else
                {
                    //Construir task y guardarlo
                    TaskModel newTask = new TaskModel(strTitle, strDescription, boolDone, intPercentage);
                    TaskDAO.addTask(newTask);
                }

                //Regresar a ultimo controlador
                this.NavigationController.PopViewController(true);

            };

            //Accion de boton cancel
            this.btnCancel.TouchUpInside += delegate
            {
                //Regresar a ultimo controlador
                this.NavigationController.PopViewController(true);
            };

            //Accion de boton delete
            this.btnDelete.TouchUpInside += delegate 
            {
                TaskDAO.deleteTask(this.task);
                this.NavigationController.PopViewController(true);
            };

            //Cuando el usuario oprime el switch
            this.switchDone.TouchUpInside += delegate
            {
                int intPercentage;
                if (this.switchDone.On)
                {
                    //La tarea estaria completada
                    intPercentage = 100;
                }
                else
                {
                    //La tarea le falta por acabarse
                    intPercentage = 50;
                }

                //Reflejar cambios en el slider y el label del porcentaje
                this.sliderPercentage.SetValue(intPercentage, true);
                this.lblPercentage.Text = ((int)this.sliderPercentage.Value).ToString() + "%";
            };

            //Cuando el usuario esta deslizando el slider
            this.sliderPercentage.AllTouchEvents += delegate 
            {
                //Porcentaje hasta donde ha deslizado el usuario
                int intPercentage = (int)this.sliderPercentage.Value;

                //Reflejar en la etiqueta
                this.lblPercentage.Text = intPercentage.ToString() + "%";

                if (intPercentage == 100)
                {
                    this.switchDone.SetState(true, true);
                }
                else
                {
                    this.switchDone.SetState(false, true);
                }
            };
		}

	}
}