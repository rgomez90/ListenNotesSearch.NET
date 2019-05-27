namespace ListenNotesSearch.NET.Models
{
    public interface IEpisode
    {
        bool MaybeAudioInvalid { get; set; }
        int PubDateMs { get; set; }
        string Audio { get; set; }
        string ListennotesEditUrl { get; set; }
        string Image { get; set; }
        string Thumbnail { get; set; }
        string Description { get; set; }
        string Title { get; set; }
        bool ExplicitContent { get; set; }
        string ListennotesUrl { get; set; }
        int AudioLengthSec { get; set; }
        string Id { get; set; }
    }
}