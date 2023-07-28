namespace FillPDFFile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Routing.RegisterRoute("editFieldsPage", typeof(EditFieldsPage));
        MainPage = new AppShell();
	}
}
