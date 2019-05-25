using System.CodeDom.Compiler;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ListenNotesSearch.NET.Models
{

    public class SubmitPodcastResponse
    {
        /// <summary>The status of this submission.</summary>
        [JsonProperty("status", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubmitPodcastResponseStatus Status { get; set; }

        [JsonProperty("podcast", Required = Required.Always)]
        public PodcastMinimum Podcast { get; set; } = new PodcastMinimum();
    }
}