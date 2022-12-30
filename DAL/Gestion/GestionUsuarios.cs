using DAL.Conexion;
using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Gestion
{
    public class GestionUsuarios
    {
        private clsMiConexion miConexion;

        public GestionUsuarios()
        {
            miConexion = new clsMiConexion();
        }

        public GestionUsuarios(string server, string name, string pass, string user)
        {
            miConexion = new clsMiConexion(server, name, user, pass);
        }


        /// <summary>
        /// <Header> inserPersona(clsPersona user) : bool </Header>
        /// Método que se encarga de insertar un registro en la tabla 
        /// Personas de la base de datos dado un objeto clsPersona 
        /// como parámetro.
        /// 
        /// </summary>
        /// <param name="user">
        ///		objeto clsPersona instanciado con atributos != null
        /// </param>
        /// <returns>
        ///		filas 
        ///			-false: no se pudo insertar el registro en la base de datos.
        ///			-true: los datos se insertaron satisfactoriamente.
        /// </returns>
        public int insertarUsuario(Usuario user)
        {
            int filas;
            SqlConnection cnn = null;
            try
            {
                cnn = miConexion.getConnection();
                SqlCommand comando = new SqlCommand();
                comando.Connection = cnn;
                comando.CommandText = "Insert into usuarios values(@id, @nick, @pass, @score)";
                comando.Parameters.AddWithValue("@id", user.IdUsuario);
                comando.Parameters.AddWithValue("@nick", user.Nick);
                comando.Parameters.AddWithValue("@pass", user.Password);
                comando.Parameters.AddWithValue("@score", user.Score);

                filas = comando.ExecuteNonQuery();
                

            }
            catch (Exception e)
            {
                throw e;
                filas = 0;
            }
            finally
            {
                if (cnn != null)
                {
                    miConexion.closeConnection(ref cnn);
                }
            }
            return filas;
        }




        /// <summary>
        /// <Header> deletePersona(int id) : bool </Header>
        /// Método que se encarga de eliminar un registro en la tabla 
        /// Personas de la base de datos dado un entero que corresponda
        /// a la propiedad id de un registro de la base de datos
        /// como parámetro.
        /// 
        /// <pre>
        ///		id debe ser un entero correspondiente al id de un registro de la tabla Personas de la base de datos.
        /// </pre>
        /// </summary>
        /// <param name="id">
        ///		entero correspondiente al atributo Id de un objeto clsPersona	
        /// </param>
        /// <returns>
        ///		filas 
        ///			-false: no se pudo eliminar el registro en la base de datos.
        ///			-true: el registro se eliminó satisfactoriamente.
        /// </returns>
        public int deleteUsuario(int id)
        {
            int filas;
            SqlConnection cnn = null;
            try
            {
                cnn = miConexion.getConnection();
                SqlCommand comando = new SqlCommand();
                comando.Connection = cnn;
                comando.CommandText = "Delete From Usuarios where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                filas = comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cnn != null)
                {
                    miConexion.closeConnection(ref cnn);
                }
            }

            return filas;

        }



        /// <summary>
        /// <Header> editPersona(int id) : bool </Header>
        /// Método que se encarga de editar un registro de la tabla 
        /// Personas de la base de datos dado un entero que corresponda
        /// a la propiedad id de un registro de la base de datos
        /// y un objeto clsPersona con los cambios que se deseen realizar
        /// como parámetro y un entero correspondiente al id del registro que se desea atacar.
        /// 
        /// <pre>
        ///		id debe ser un entero correspondiente al id de un registro de la tabla Personas de la base de datos.
        /// </pre>
        /// </summary>
        /// <param name="id">
        ///		entero correspondiente al atributo Id de un objeto clsPersona	
        /// </param>
        /// <param name="usuario">
        ///		objeto clsPersona con los cambios que se desea reaalizar en el registro
        /// </param>
        /// <returns>
        ///		filas 
        ///			-false: no se pudo editar el registro en la base de datos.
        ///			-true: el registro se editó satisfactoriamente.
        /// </returns>
        /// 
        public int editUsuario(Usuario usuario, int id)
        {
            int filas;
            SqlConnection cnn = null;
            try
            {


                cnn = miConexion.getConnection();
                SqlCommand comando = new SqlCommand();
                comando.Connection = cnn;
                comando.CommandText = "Update Usuarios set nick = @nombre, password = @password, score = @score Where id = @id";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", usuario.Nick);
                comando.Parameters.AddWithValue("@password", usuario.Password);
                comando.Parameters.AddWithValue("@score", usuario.Score);
                filas = comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cnn != null)
                {
                    miConexion.closeConnection(ref cnn);
                }
            }

            return filas;

        }




        public Usuario getUsuarioByNickAndPassword(String nick, String password)
        {
            Usuario usuario = null;
            SqlConnection cnn = null;
            try
            {


                cnn = miConexion.getConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                comando.Connection = cnn;
                comando.CommandText = "Select * From Personas where nick = @nick and password = @password";
                comando.Parameters.AddWithValue("@nick", nick);
                comando.Parameters.AddWithValue("@password", password);

                lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        usuario = new(
                            lector.GetInt32(0),
                            lector.GetString(1),
                            lector.GetString(2),
                            lector.GetInt32(3)
                            );
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cnn != null)
                    miConexion.closeConnection(ref cnn);
            }
            return usuario;
        }


    /// <summary>
    /// <Header> editPersona(int id) : bool </Header>
    /// Método que se encarga de editar un registro de la tabla 
    /// Personas de la base de datos dado un entero que corresponda
    /// a la propiedad id de un registro de la base de datos
    /// y un objeto clsPersona con los cambios que se deseen realizar
    /// como parámetro y un entero correspondiente al id del registro que se desea atacar.
    /// 
    /// <pre>
    ///		id debe ser un entero correspondiente al id de un registro de la tabla Personas de la base de datos.
    /// </pre>
    /// </summary>
    /// <param name="id">
    ///		entero correspondiente al atributo Id de un objeto clsPersona	
    /// </param>
    /// <param name="persona">
    ///		objeto clsPersona con los cambios que se desea reaalizar en el registro
    /// </param>
    /// <returns>
    ///		filas 
    ///			-false: no se pudo editar el registro en la base de datos.
    ///			-true: el registro se editó satisfactoriamente.
    /// </returns>
    /// 
    public Usuario getUsuarioById(int id)
        {
            Usuario usuario = null;
            SqlConnection cnn = null;
            try
            {


                cnn = miConexion.getConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                comando.Connection = cnn;
                comando.CommandText = "Select * From Personas where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        usuario = new(
                            lector.GetInt32(0),
                            lector.GetString(1),
                            lector.GetString(2),
                            lector.GetInt32(3)
                            );
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cnn != null)
                    miConexion.closeConnection(ref cnn);
            }
            return usuario;
        }


    }
}
