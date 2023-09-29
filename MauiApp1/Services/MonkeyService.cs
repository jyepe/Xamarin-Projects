namespace MauiApp1.Services
{
    public class MonkeyService
    {
        //global private monkey list
        private List<Monkey> _monkeys = new();
        private readonly HttpClient _httpClient;

        public MonkeyService()
        {
            _httpClient = new HttpClient();
        }

        //get monkey method to return monkey list using http client
        public async Task<List<Monkey>> GetMonkeys()
        {
            //if monkey list is empty
            if (_monkeys.Count == 0)
            {
                //get json data from url
                var json = await _httpClient.GetStringAsync("https://montemagno.com/monkeys.json");

                //deserialize json data into monkey list
                _monkeys = JsonConvert.DeserializeObject<List<Monkey>>(json);
            }

            //return monkey list
            return _monkeys;
        }
    }
}
