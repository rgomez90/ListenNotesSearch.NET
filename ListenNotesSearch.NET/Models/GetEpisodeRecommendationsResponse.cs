using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetEpisodeRecommendationsResponse
    {
        [JsonProperty("recommendations", Required = Required.Always)]
        public ICollection<EpisodeSimple> Recommendations { get; set; } = new Collection<EpisodeSimple>();
    }
}