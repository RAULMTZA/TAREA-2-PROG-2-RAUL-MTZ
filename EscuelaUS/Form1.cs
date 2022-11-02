using EscuelaUS.datos;
using EscuelaUS.datos.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscuelaUS
{
    public partial class Universidad : Form
    {
        public Universidad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // BOTON GUARDAR
        {
            //validar campos del formulario formNombre formCalificacion
            if (formNombre.Text.Trim() == "")
            {
                MessageBox.Show("INGRESE NOMBRE");
            }
            else if (formNombre.Text.Trim().Length <= 5)
            {
                MessageBox.Show("NOMBRE DEBE SER MAYOR A 5 CARACTERES");
            }
            else
            {
                //llamar al modelo
                Alumno al =new Alumno();
                al.Nombre = formNombre.Text.Trim().ToUpper();//PASA DEL FORMULARIO EL ATRIBUTO
                al.Calificacion = Convert.ToInt32(formCalificacion.Text.Trim());

                if (AlumnoController.guardar(al)) //AQUI SE LLAMA A GUARDAR
                {
                    MessageBox.Show("REGISTRO GUARDADO");
                }
                else
                {
                    MessageBox.Show("ERROR NO SE GUARDO EL REGISTRO");
                }
            }
            //insertarlos
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AlumnoController.leer();
        }

        private void Universidad_Load(object sender, EventArgs e)  // DESPLIEGUE DE DATOS EN DATA GRID
        {
            dataGridView1.DataSource = AlumnoController.leer();
        }

        private void button2_Click(object sender, EventArgs e)  // BOTON BUSCAR
        {
            MessageBox.Show(AlumnoController.Buscar(formNombre.Text.ToString()).ToString());
        }

        private void button3_Click(object sender, EventArgs e) // BOTON ACTUALIZAR
        {
            if (AlumnoController.Actualizar(formNombre.Text.ToString(), Convert.ToInt32(formCalificacion.Text.Trim())))
                MessageBox.Show("REGISTRO ACTUALIZADO"); 
            else
                MessageBox.Show("ERROR NO SE ACTUALIZO EL REGISTRO");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AlumnoController.leer();
        }

        private void button4_Click(object sender, EventArgs e)  // BOTON DE ELIMINAR
        {
            if (AlumnoController.Borrar(formNombre.Text.ToString())) //EVALUA SI DE ALUMNO CONTROLLER METODO BORRAR EL PARAMETRO nombre INGRESADO
                MessageBox.Show("REGISTRO ELIMINADO");
            else
                MessageBox.Show("ERROR NO SE ELIMINO EL REGISTRO");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AlumnoController.leer();
        }
    }
}
