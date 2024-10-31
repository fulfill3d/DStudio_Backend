using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Scene
{
    public class SceneManifest
    {
        [JsonProperty("collisionsEnabled")]
        public bool CollisionsEnabled { get; set; }

        [JsonProperty("clearColor")]
        public List<int> ClearColor { get; set; }

        [JsonProperty("camera")]
        public Camera Camera { get; set; }

        [JsonProperty("lights")]
        public List<Light> Lights { get; set; }
    }
}

