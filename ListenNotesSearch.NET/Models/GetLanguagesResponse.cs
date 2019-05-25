using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetLanguagesResponse
    {
        [JsonProperty("languages", Required = Required.Always)]
        public ICollection<string> Languages { get; set; } = new Collection<string>();
    }
}