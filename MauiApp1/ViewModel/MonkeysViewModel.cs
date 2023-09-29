namespace MauiApp1.ViewModel
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        private readonly MonkeyService _monkeyService;

        [ObservableProperty]
        private Monkey _selectedMonkey;

        [ObservableProperty]
        private bool _isRefreshing;

        IGeolocation _geolocation;

        public ObservableCollection<Monkey> Monkeys { get; set; }

        public MonkeysViewModel(MonkeyService monkeyService, IGeolocation geolocation)
        {
            Title = "Monkey Finder";
            Monkeys = new ObservableCollection<Monkey>();
            _monkeyService = monkeyService;
            _geolocation = geolocation;
        }

        [RelayCommand]
        private async Task GetClosestMonkey()
        {
            // if is busy or monkeys is empty
            if (IsBusy || Monkeys.Count == 0)
            {
                return;
            }

            try
            {
                // Get cached location, else get real location
                var location = await _geolocation.GetLastKnownLocationAsync() ?? 
                               await _geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(30)));

                // Find closest monkey
                var closest = Monkeys.MinBy(x =>
                    location.CalculateDistance(new Location(x.Latitude, x.Longitude), DistanceUnits.Miles));

                // Display closest monkey
                await Application.Current.MainPage.DisplayAlert("Closest Monkey", closest.Name, "OK");
            }
            catch (Exception e)
            {
                // Display error
                await Application.Current.MainPage.DisplayAlert("Error!", e.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task MonkeySelected()
        {
            var parameters = new Dictionary<string, object>()
            {
                { "Monkey", SelectedMonkey }
            };
            await Shell.Current.GoToAsync(nameof(DetailsPage), true, parameters);
        }

        [RelayCommand]
        private async Task LoadMonkeys()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var monkeys = await _monkeyService.GetMonkeys();
                Monkeys.Clear();
                foreach (var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to load monkeys: {ex.Message}");
                //display alert
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
