using DAL.Gestion;
using DAL.Listas;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace BL.Gestion
{
	public class GestionUsuariosBL
	{
        GestionUsuarios dal;


        public GestionUsuariosBL()
        {
            dal = new GestionUsuarios();
        }

	

		public void generarTablaBL()
        {
            dal.generarTabla();
        }

		public int insertarUsuarioBL(Usuario user)
        {
            return dal.insertarUsuario(user);
        }

		public bool testIfExistsBL(string name)
        {
            return dal.testIfExists(name);
        }



		public int deleteUsuarioBL(string id)
        {
            return dal.deleteUsuario(id);
        }



        public int editUsuarioBL(Usuario usuario, string id)
        {
            return dal.editUsuario(usuario, id);
        }



        public Usuario getUsuarioByIdBL(string id)
        {
            return dal.getUsuarioById(id);
        }

        public Usuario getUsuarioByNickAndPasswordBL(string nick, string password)
        {
            return dal.getUsuarioByNickAndPassword(nick, password);
        }
    }
}
