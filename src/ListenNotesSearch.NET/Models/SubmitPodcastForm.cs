using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class SubmitPodcastForm
    {
        /// <summary>A valid podcast rss url</summary>
        [JsonProperty("rss", Required = Required.Always)]
        public string Rss { get; set; }

        /// <summary>A valid email address. If **email** is specified, then we'll notify this email address once the podcast is accepted.</summary>
        [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    }
}