using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Canvas
{
    public class Canvas
    {
        [JsonProperty("scaleFactor")]
        public int ScaleFactor { get; set; }
        
        [JsonProperty("width")]
        public int Width { get; set; }
        
        [JsonProperty("height")]
        public int Height { get; set; }
        
        [JsonProperty("intersectionMode")]
        public string IntersectionMode { get; set; }
    }
}