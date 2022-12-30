namespace Entities
{
	public class Usuario
	{
		private int idUsuario;
		private String nick;
		private String password;
		private int score;


		public int IdUsuario { get { return idUsuario; } }
		public String Nick { get { return nick; } set { nick = value; } }

		public String Password { get { return password; } set { password = value; } }

		public int Score { get { return score; } set { score = value; } }

		public Usuario(int id, string nick, string password, int score)
		{
			idUsuario= id;
			this.nick = nick;
			this.password = password;
			this.score = score;
		}

        public Usuario( string nick, string password, int score)
        {
            this.nick = nick;
            this.password = password;
            this.score = score;
        }


    }
}