using Newtonsoft.Json;

namespace DStudio.API.Data.Models.Product
{
    public class Texture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("hasAlpha")]
        public bool HasAlpha { get; set; }

        [JsonProperty("isDesignTexture")]
        public bool IsDesignTexture { get; set; }

        [JsonProperty("generateMipMaps")]
        public bool GenerateMipMaps { get; set; }

        [JsonProperty("addressMode")]
        public string AddressMode { get; set; }

        [JsonProperty("samplingMode")]
        public string SamplingMode { get; set; }

        [JsonProperty("uScale")]
        public int UScale { get; set; }

        [JsonProperty("vScale")]
        public int VScale { get; set; }

        [JsonProperty("invertY")]
        public bool? InvertY { get; set; }

        [JsonProperty("noMipmapOrOptions")]
        public bool? NoMipmapOrOptions { get; set; }
    }
}