using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroC.Entities
{
    public class ZCImage
    {
        [JsonProperty("id")]
        public int Id { get; init; }

        [JsonProperty("small")]
        public Uri Small { get; init; }

        [JsonProperty("medium")]
        public Uri Medium { get; init; }

        [JsonProperty("large")]
        public Uri Large { get; init; }

        [JsonProperty("full")]
        public Uri Full { get; init; }

        [JsonProperty("width")]
        public int Width { get; init; }

        [JsonProperty("height")]
        public int Height { get; init; }

        [JsonProperty("size")]
        public int Size { get; init; }

        [JsonProperty("hash")]
        public string Hash { get; init; }

        [JsonProperty("parent")]
        public int Parent { get; init; }

        [JsonProperty("children")]
        public int Children { get; init; }

        [JsonProperty("primary")]
        public string PrimaryTag { get; init; }

        [JsonProperty("tags")]
        public List<string> RawTags { get; init; }

        [JsonConstructor]
        internal ZCImage() { }
    }
}
