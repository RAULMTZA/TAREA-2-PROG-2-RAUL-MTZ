﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaUS.datos
{
    class Conexion
    {
        SqlConnection con;//INSTANCIA
        
        public Conexion() //Constructor inicialice la clase con valores
        {
            con = new SqlConnection("Data Source=MXMEXL0006\\SQLEXPRESS;Initial Catalog=alumnos;Integrated Security=True");
        }
        public SqlConnection conectar()//METODO PARA CONECTAR
        {
            con.Open();
            return con; 
        }
        public bool desconectar()//METODO PARA DESCONECTAR
        {
            con.Close();
            return true;
        }
    }
}
