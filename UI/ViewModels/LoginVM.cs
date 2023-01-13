﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ViewModels.Utilities;
using Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BL.Listas;
using UI.Views;
using BL.Gestion;

namespace UI.ViewModels
{
    public partial class LoginVM : VMBase
    {
		#region Atributes

		private ListaUsuariosBL usuariosBL => new();

		private GestionUsuariosBL gestionBL => new();

		[ObservableProperty]
        public string nick;

        [ObservableProperty]
        public string password;

		#endregion
		#region Constructors

		public LoginVM() {
			//gestionBL.generarTablaBL();
			//gestionBL.insertarUsuarioBL(new Usuario("Admin", "Admin", 900 ));
		}

		#endregion

		#region Commands

		/// <summary>
		/// Comando que se encarga de, si el usuario y la contraseña que se introdujeron coinciden con los datos que se encuentran en la base de datos,
		/// enviar al usuario a la página de inicio del juego.
		/// </summary>
		[RelayCommand]
		public async void SignIn()
		{

			try
			{
				var user = gestionBL.getUsuarioByNickAndPasswordBL(nick, password);

				Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
				var usuari = new Dictionary<string, object>();
				usuari.Add("user", user);
				await Shell.Current.GoToAsync("main", false, usuari);
				
			}
			catch (Exception) 
			{
				await Shell.Current.DisplayAlert("Empareja2","usuario o contraseña incorrectos","Ok");
			}
		
			
		}

		/// <summary>
		/// Comando que se encarga de, si el usuario es nuevo, crear un usuario en la base de datos y,
		/// posteriormente, enviarlo a la página de inicio
		/// 
		/// Precondiciones:
		/// Postcondiciones:
		/// 
		/// </summary>
		[RelayCommand]
		public async void SignUp()
		{
			//Compruebo que no exista ese mismo nickname en la tabla usuariosc  de la base de datos
			if (gestionBL.testIfExistsBL(nick))
				return;


			Usuario user = new Usuario(Nick, Password, 0);

			

			var listaAux = usuariosBL.getListadoCompletoUsuariosBL();

			var salir = false;

		
				gestionBL.insertarUsuarioBL(user);
				var usuari = new Dictionary<string, object>();
				usuari.Add("user", user);
				await Shell.Current.GoToAsync("main",false, usuari);
			
		}

		#endregion
	}
}
