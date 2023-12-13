using Newtonsoft.Json;

namespace Mapbox.Razor.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public partial class Layer : IMapboxClass
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "layer_" + Guid.NewGuid().ToString();

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        [JsonProperty("layout")]
        public LayoutDetails? Layout { get; set; }

        [JsonProperty("paint")]
        public PaintDetails? Paint { get; set; }

        [JsonProperty("source-layer")]
        public string? SourceLayer { get; set; }

        [JsonProperty("filter")]
        public List<dynamic>? Filter { get; set; }

        [JsonProperty("minzoom")]
        public double? MinZoom { get; set; }

        [JsonProperty("maxzoom")]
        public double? MaxZoom { get; set; }

        [JsonProperty("metadata")]
        public dynamic? MeteData { get; set; }
        [JsonIgnore]
        public bool Clickable { get; set; } = false;

        [JsonProperty("dashArraySequence")]
        public List<List<double>>? DashArraySequence { get; set; }

        [JsonIgnore]
        public double? AnimationSpeed { get; set; }

        public void AddAnimation(double dashLength, double animationSpeed)
        {
            AnimationSpeed = animationSpeed;
            DashArraySequence = new List<List<double>>();

            double nrOfSteps = 30 / animationSpeed;
            for (int i = 0; i - 1 < nrOfSteps; i++)
            {
                double currentStep = i * dashLength / nrOfSteps;
                DashArraySequence.Add(new List<double> { currentStep, dashLength, dashLength - currentStep });
            }
            for (int i = 1; i < nrOfSteps; i++)
            {
                double currentStep = i * dashLength / nrOfSteps;
                DashArraySequence.Add(new List<double> { 0.0, currentStep, dashLength, dashLength - currentStep });
            }
        }
    }
}
