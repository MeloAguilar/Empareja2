using UI.Views;

namespace UI
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();



			Routing.RegisterRoute("game", typeof(GamePage));
			Routing.RegisterRoute("scoreboard", typeof(ScoreboardPage));
			Routing.RegisterRoute("main", typeof(MainPAge));
		}
	}
}