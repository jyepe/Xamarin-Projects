namespace MauiApp1.ViewModel
{
    [QueryProperty(nameof(Monkey), "Monkey")]
    public partial class MonkeyDetailsViewModel : BaseViewModel
    {
        IMap _map;

        public MonkeyDetailsViewModel(IMap map)
        {
            _map = map;
        }
        
        [ObservableProperty] 
        private Monkey _monkey;

        // Method that opens the map on the monkey's location
        [RelayCommand]
        private async Task OpenMap()
        {
            await _map.OpenAsync(new Location(Monkey.Latitude, Monkey.Longitude));
        }
    }
}
