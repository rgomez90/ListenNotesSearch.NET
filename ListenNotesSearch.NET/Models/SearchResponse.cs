using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    public class SearchResponse
    {
        /// <summary>Pass this value to the **offset** parameter to do pagination of search results.</summary>
        [JsonProperty("next_offset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int NextOffset { get; set; }

        /// <summary>The time it took to fetch these search results. In seconds.</summary>
        [JsonProperty("took", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Took { get; set; }

        /// <summary>The total number of search results.</summary>
        [JsonProperty("total", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        /// <summary>The number of search results in this page.</summary>
        [JsonProperty("count", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Count { get; set; }

        /// <summary>A list of search results.</summary>
        [JsonProperty("results", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<EpisodeSearchResult> Results { get; set; }
    }
}