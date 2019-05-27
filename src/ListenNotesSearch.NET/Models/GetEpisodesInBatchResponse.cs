using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    public class GetEpisodesInBatchResponse
    {
        [JsonProperty("episodes", Required = Required.Always)]
        public ICollection<EpisodeSimple> Episodes { get; set; } = new Collection<EpisodeSimple>();
    }
}