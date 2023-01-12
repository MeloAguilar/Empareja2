using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
	public class Card
	{


		public string urlFront { get; set; }

		public string urlBack { get; set; }

		public bool isFront { get; set; }

		public Card(string _front)
		{
			this.urlFront = _front;
			this.urlBack = "back.jpg";
			this.isFront = false;
		}


	}
}
