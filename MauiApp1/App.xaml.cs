namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjcyNTY3OEAzMjMzMmUzMDJlMzBDMGNGd2VtYUJzY0l2NlcrVDFuMXdnbE9rbGpid0x5d04yS0Rzc0ZGZFQ4PQ==");
        InitializeComponent();

		MainPage = new AppShell();
	}
}
