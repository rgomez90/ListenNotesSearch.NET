using System.Runtime.Serialization;

namespace ListenNotesSearch.NET.Models
{

    public enum Sort
    {
        [EnumMember(Value = @"recent_first")] RecentFirst = 0,

        [EnumMember(Value = @"oldest_first")] OldestFirst = 1
    }
}