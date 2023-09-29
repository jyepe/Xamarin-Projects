namespace MauiApp1.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _title;
        
        public bool IsNotBusy => !IsBusy;
    }
}
