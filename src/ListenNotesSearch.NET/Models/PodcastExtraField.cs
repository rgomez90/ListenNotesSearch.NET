using Newtonsoft.Json;

namespace ListenNotesSearch.NET.Models
{

    public class PodcastExtraField
    {
        /// <summary>YouTube url affiliated with this podcast</summary>
        [JsonProperty("youtube_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string YoutubeUrl { get; set; }

        /// <summary>Facebook username affiliated with this podcast</summary>
        [JsonProperty("facebook_handle", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string FacebookHandle { get; set; }

        /// <summary>Instagram username affiliated with this podcast</summary>
        [JsonProperty("instagram_handle", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public string InstagramHandle { get; set; }

        /// <summary>Twitter username affiliated with this podcast</summary>
        [JsonProperty("twitter_handle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterHandle { get; set; }

        /// <summary>WeChat username affiliated with this podcast</summary>
        [JsonProperty("wechat_handle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string WechatHandle { get; set; }

        /// <summary>Patreon username affiliated with this podcast</summary>
        [JsonProperty("patreon_handle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PatreonHandle { get; set; }

        /// <summary>Google Podcasts url for this podcast</summary>
        [JsonProperty("google_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string GoogleUrl { get; set; }

        /// <summary>LinkedIn url affiliated with this podcast</summary>
        [JsonProperty("linkedin_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string LinkedinUrl { get; set; }

        /// <summary>Spotify url for this podcast</summary>
        [JsonProperty("spotify_url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SpotifyUrl { get; set; }

        /// <summary>Url affiliated with this podcast</summary>
        [JsonProperty("url1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Url1 { get; set; }

        /// <summary>Url affiliated with this podcast</summary>
        [JsonProperty("url2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Url2 { get; set; }

        /// <summary>Url affiliated with this podcast</summary>
        [JsonProperty("url3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Url3 { get; set; }
    }
}