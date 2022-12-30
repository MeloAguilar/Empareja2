using DAL.Listas;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listas
{
	public class ListaUsuariosBL
	{
		ListaUsuarios dal;


		ListaUsuariosBL()
		{
			dal = new ListaUsuarios();
		}


        public ObservableCollection<Usuario> getListadoCompletoUsuariosBL()
		{
			return new ObservableCollection<Usuario>(dal.getListadoCompletoUsuarios());
		}

    }
}
