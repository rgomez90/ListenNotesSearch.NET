using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class GetGenresResponse
    {
        [JsonProperty("genres", Required = Required.Always)]
        public ICollection<Genre> Genres { get; set; } = new Collection<Genre>();
    }
}