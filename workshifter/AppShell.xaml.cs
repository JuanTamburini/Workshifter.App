using workshifter.View;

namespace workshifter;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(WorkshiftPage), typeof(WorkshiftPage));
	}
}
