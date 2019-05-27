using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetPodcastRecommendationsResponse
    {
        [JsonProperty("recommendations", Required = Required.Always)]
        public ICollection<PodcastSimple> Recommendations { get; set; } = new Collection<PodcastSimple>();
    }
}