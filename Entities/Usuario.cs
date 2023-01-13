namespace Entities
{
	public class Usuario
	{
		private String nick;
		private String password;
		private long score;


		public String Nick { get { return nick; } set { nick = value; } }

		public String Password { get { return password; } set { password = value; } }

		public long Score { get { return score; } set { score = value; } }

		public Usuario( string nick, string password, long score)
		{
			this.nick = nick;
			this.password = password;
			this.score = score;
		}

     


    }
}