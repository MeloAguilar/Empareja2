using DAL.Conexion;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.Listas
{
    public class ListaUsuarios
    {
        clsMiConexion miConexion;

        List<Usuario> lista = new();

        public ListaUsuarios()
        {
            miConexion = new clsMiConexion();
            //Comprobamos que se pueda abrir la conexion con el servidor
            try
            {
                var cnn = miConexion.getConnection();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Método que se encarga de rellenar una lista de objetos tipo clsPersona
        /// a partir de una llamada a la base de datos.
        /// 
        /// Precondiciones: La Propiedad de la clase 
        /// Postcondiciones:
        /// </summary>
        /// <returns></returns>
        public List<Usuario> getListadoCompletoUsuarios()
        {

            if (lista?.Count > 0)
                return lista;

            SqlConnection cnn = null;

            cnn = miConexion.getConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader miLector;

            cmd.CommandText = "Select * From Usuarios";

            cmd.Connection = cnn;
            miLector = cmd.ExecuteReader();
            if (miLector.HasRows)
            {

                while (miLector.Read())
                {
                    lista.Add(new Usuario(miLector.GetInt32(0), miLector.GetString(1), miLector.GetString(2), miLector.GetInt32(3)));

                }
            }


            if (cnn != null)
            {
                miConexion.closeConnection(ref cnn);
            }




            return lista;

        }


    }
}
