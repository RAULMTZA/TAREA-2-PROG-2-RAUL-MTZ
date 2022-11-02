using EscuelaUS.datos.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaUS.datos
{
    class AlumnoController
    { 
        public static bool guardar(Alumno al)
        {
            
            Conexion con = new Conexion();  //CONECTARSE A LA BASE DE DATOS
            //PASA CONSULTA INSERT INTO Alumno(nombre, calificacion) VALUES('xxxx',xx))
            string sql = "INSERT INTO tb_alumno (nombre, calificacion) VALUES('"+al.Nombre+"','"+al.Calificacion+"')";
            //ACCEDE A LA BASE DE DATOS Y PASA CONSULTA
            SqlCommand inserta = new SqlCommand(sql, con.conectar());
            //(INSERT INTO Alumno(nombre, calificacion) VALUES('juan',95)),("Data Source= AQUI PONES LA DIR DEL SERVER SQL;Initial Catalog=Universidad;Integrated Security=True")
            
            int insertados = inserta.ExecuteNonQuery();
            if(insertados == 1)
            {
                con.desconectar();//SE CIERRA CONEXION
                return true;
            }
            else
            {
                con.desconectar();
                return false;
            }
        }

        public static DataTable leer()  // DESPLIEGUE DE INFORMACION EN EL DATAGRID
        {
            DataTable rd=new DataTable();
            Conexion con = new Conexion();
            string sql = "SELECT * FROM tb_alumno;"; // CONSULTA EB LA BASE DE DATOS
            SqlCommand com = new SqlCommand(sql, con.conectar());
            rd.Load(com.ExecuteReader());
            con.desconectar();
            return rd;
        }

        public static int Buscar(string nombre)  // BOTON BUSCAR 
        {
            int calificacion;
            calificacion = 0;
            DataTable rd = new DataTable();
            Conexion con = new Conexion();
            string sql = "SELECT calificacion FROM tb_alumno WHERE nombre = '" + nombre + "';"; // CONSULTA EN LA BASE DE DATOS
            SqlCommand com = new SqlCommand(sql, con.conectar());
            calificacion = Convert.ToInt32(com.ExecuteScalar());
            con.desconectar();
            return calificacion;
        }

        public static bool Actualizar(string nombre, int calificacion) // BOTON ACTUALIZAR
        {
            Conexion con = new Conexion();
            // CON UPDATE ACTUALIZA LA BD Y CON WHERE INDICAS QUE SE ACTUAIZA LA DEL DATO nombre
            string sql = "UPDATE tb_alumno SET calificacion = " + calificacion.ToString() +" WHERE nombre = '" + nombre + "';";
            SqlCommand com = new SqlCommand(sql, con.conectar());
            int actualizados = com.ExecuteNonQuery();//1
            if (actualizados == 1)
            {
                con.desconectar();
                return true;
            }
            else
            {
                con.desconectar();
                return false;
            }
        }

        public static bool Borrar(string nombre) // BOTON ELIMINAR
        {
            Conexion con = new Conexion();
            // BORRAMOS CON ORDEN DELETE CON EL CAMPO WHERE nombre
            string sql = "DELETE FROM tb_alumno WHERE nombre = '" + nombre + "';";
            SqlCommand com = new SqlCommand(sql, con.conectar());
            int borrados = com.ExecuteNonQuery();//1
            if (borrados == 1)
            {
                con.desconectar();
                return true;
            }
            else
            {
                con.desconectar();
                return false;
            }
        }
    }
}
