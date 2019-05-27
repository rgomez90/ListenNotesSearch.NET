using System.Runtime.Serialization;

namespace ListenNotesSearch.NET.Models
{
    public enum Type
    {
        [EnumMember(Value = @"episode")]
        Episode = 0,

        [EnumMember(Value = @"podcast")]
        Podcast = 1,

        [EnumMember(Value = @"curated")]
        Curated = 2
    }
}