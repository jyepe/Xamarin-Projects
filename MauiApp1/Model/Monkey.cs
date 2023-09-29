namespace MauiApp1.Model
{
    public class Monkey
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Location))]
        public string Location { get; set; }

        [JsonProperty(nameof(Details))]
        public string Details { get; set; }

        [JsonProperty(nameof(Image))]
        public string Image { get; set; }

        [JsonProperty(nameof(Population))]
        public long Population { get; set; }

        [JsonProperty(nameof(Latitude))]
        public double Latitude { get; set; }

        [JsonProperty(nameof(Longitude))]
        public double Longitude { get; set; }
    }
}
