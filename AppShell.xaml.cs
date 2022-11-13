namespace Lyst;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.AllNotesPage), typeof(Views.AllNotesPage));
    }
}