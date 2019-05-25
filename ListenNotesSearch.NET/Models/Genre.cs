using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class Genre
    {
        /// <summary>Genre id</summary>
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>Genre name.</summary>
        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>Parent genre id.</summary>
        [JsonProperty("parent_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int ParentId { get; set; }
    }
}