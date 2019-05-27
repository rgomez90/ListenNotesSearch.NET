using System.Runtime.Serialization;

namespace ListenNotesSearch.NET.Models
{

    public enum SubmitPodcastResponseStatus
    {
        [EnumMember(Value = @"found")] Found = 0,

        [EnumMember(Value = @"in review")] InReview = 1
    }
}