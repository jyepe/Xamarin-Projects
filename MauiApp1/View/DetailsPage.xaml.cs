namespace MauiApp1.View
{
	public partial class DetailsPage : ContentPage
	{
		public DetailsPage(MonkeyDetailsViewModel monkeyDetailsViewModel)
		{
			InitializeComponent();
			BindingContext = monkeyDetailsViewModel;
		}
	}
}