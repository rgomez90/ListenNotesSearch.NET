using System;

namespace ListenNotesSearch.NET.Models
{
    public interface IPodcast
    {
        bool IsClaimed { get; set; }
        bool ExplicitContent { get; set; }
        string Website { get; set; }
        int TotalEpisodes { get; set; }
        DateTime EarliestPubDateMs { get; set; }
        string Rss { get; set; }
        DateTime LatestPubDateMs { get; set; }
        string Title { get; set; }
        string Language { get; set; }
        string Description { get; set; }
        string Email { get; set; }
        string Image { get; set; }
        string Thumbnail { get; set; }
        string ListennotesUrl { get; set; }
        string Id { get; set; }
        string Country { get; set; }
        string Publisher { get; set; }
        int ItunesId { get; set; }
        PodcastLookingForField LookingFor { get; set; }
        PodcastExtraField Extra { get; set; }
        GenreIdsField GenreIds { get; set; }
    }
}