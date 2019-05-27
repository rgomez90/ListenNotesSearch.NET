using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class PodcastLookingForField
    {
        /// <summary>Whether this podcast is looking for cohosts.</summary>
        [JsonProperty("cohosts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Cohosts { get; set; }

        /// <summary>Whether this podcast is looking for cross promotion opportunities with other podcasts.</summary>
        [JsonProperty("cross_promotion", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public bool CrossPromotion { get; set; }

        /// <summary>Whether this podcast is looking for sponsors.</summary>
        [JsonProperty("sponsors", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Sponsors { get; set; }

        /// <summary>Whether this podcast is looking for guests.</summary>
        [JsonProperty("guests", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Guests { get; set; }
    }
}