using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{
    public class GetEpisodesInBatchForm
    {
        /// <summary>Comma-separated list of episode ids.</summary>
        [JsonProperty("ids", Required = Required.Always)]
        public string Ids { get; set; }
    }
}