using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    public class TypeaheadResponse
    {
        /// <summary>Search term suggestions.</summary>
        [JsonProperty("terms", Required = Required.Always)]
        public ICollection<string> Terms { get; set; } = new Collection<string>();

        /// <summary>Genre suggestions. It'll show up when the **show_genres** parameter is *1*.</summary>
        [JsonProperty("genres", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<Genre> Genres { get; set; }

        /// <summary>Podcast suggestions. It'll show up when the **show_podcasts** parameter is 1.</summary>
        [JsonProperty("podcasts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<PodcastTypeaheadResult> Podcasts { get; set; }
    }
}