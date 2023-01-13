using CommunityToolkit.Mvvm.ComponentModel;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;
using UI.ViewModels.Utilities;

namespace UI.ViewModels
{
	[QueryProperty(nameof(Usuario), nameof(User))]

	public partial class GameVM : VMBase, IQueryAttributable
	{
		#region CardFronts
		string front1 = "badersaber";
		string front2 = "lukesaber";
		string front3 = "yodasaber";
		string front4 = "wimdusaber";
		string front5 = "tanosabers";
		string front6 = "quigonsaber";
		string front7 = "obiwansaber";
		string front8 = "mandalorian";
		string front9 = "kylosaber";
		string front10 = "dookusaber";
		#endregion

		#region Atributes

		[ObservableProperty]
		Usuario user;

		[ObservableProperty]
		//Entero que podrá ser 0, 1 o 2, que corresponderá, 0 con una disposicion 2x4, 1 con una disposicion 3x3 y 2 con una disposicion de 4x4
		int mode;


		[ObservableProperty]
		Card selectedCard;

		public ObservableCollection<Card> Cards { get; set; }

		#endregion

		#region Constructors

		public GameVM()
		{
			start();
			getCards();
		}

		#endregion

		#region Commands

		#endregion

		#region Utilities

		private async void start()
		{
			var result = await Shell.Current.DisplayActionSheet("Empareja2", "cancelar", "atrás", new string[] { "medio", "facil", "dificil" });
			switch (result)
			{
				case "facil": mode = 0; break;
				case "medio": mode = 1; break;
				case "dificil": mode = 2; break;
				default: new GameVM(); break;
			}
		}


		/// <summary>
		/// Método que se encarga de darle elatributo urlFront a un objeto de tipo Card segun el entero que le llegue como parámetro
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private Card eleccionCarta(int value)
		{
			Card card;
			switch (value)
			{
				case 1:
					card = new Card(front1);
					break;

				case 2:
					card = new Card(front2);
					break;
				case 3:
					card = new Card(front3);
					break;
				case 4:
					card = new Card(front4);
					break;
				case 5:
					card = new Card(front5);
					break;
				case 6:
					card = new Card(front6);
					break;
				case 7:
					card = new Card(front7);
					break;
				case 8:
					card = new Card(front8);
					break;
				case 9:
					card = new Card(front9);
					break;
				case 10:
					card = new Card(front10);
					break;
				default:
					card = new Card("null");
					break;
			}
			return card;
		}


		/// <summary>
		/// Métoido que se encarga de comprobar que todas las cartas tengan su respectiva pareja
		/// </summary>
		/// <param name="numCards"></param>
		/// <returns></returns>
		private bool comprobarCartas(int[] numCards)
		{
			bool success = true;
			for (int i = 0; i < numCards.Length && success; i++)
			{
				if (numCards[i] != 2)
					success= false;
			}
			return success;
		}
		/// <summary>
		/// Método privado que sirve para generar la posicion de cada carta en cada partida.
		/// </summary>
		private void getCards()
		{
			int[] numCards;
			int modeValue;

			//Aquí se establece, según el boton pulsado por el usuario, el modo de juego, la cantidad de cartas que se utilizarán y un array de enteros en la cual cada posicion 
			if (mode == 0)
			{
				modeValue = 3;
				numCards = new int[] { 0, 0, 0 };
			}
			else if (mode == 1)
			{
				modeValue = 6;
				numCards = new int[] { 0, 0, 0, 0, 0, 0 };
			}
			else if (mode == 2)
			{
				modeValue = 8;
				numCards = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
			}
			else { modeValue = 0; numCards = new int[] { }; }
			Random random = new Random();

			int prevalue = 0;
			for (int i = 0; i < modeValue; i++)
			{
				int value = random.Next(1, modeValue);

				if (value != prevalue && numCards[i] < 2)
				{

					Cards.Add(eleccionCarta(value));
				}


				if (!comprobarCartas(numCards))
				{
					i=0;
				}
			}
		}

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			User = (Usuario)query.Values.FirstOrDefault();
		}


		#endregion
	}
}
