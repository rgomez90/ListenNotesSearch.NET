using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ListenNotesSearch.NET.Models;

namespace ListenNotesSearch.NET
{
    public interface IListenNodeSearchClient
    {
        /// <summary>Full-text search</summary>
        /// <param name="q">Search term, e.g., person, place, topic...</param>
        /// <param name="sortByDate">Sort by date or not? If 0, then sort by relevance. If 1, then sort by date.</param>
        /// <param name="type">What type of contents do you want to search for?</param>
        /// <param name="offset">Offset for search results, for pagination. You'll use **next_offset** from response for this parameter.</param>
        /// <param name="lenMin">Minimum audio length in minutes. Applicable only when type parameter is **episode**.</param>
        /// <param name="lenMax">Maximum audio length in minutes. Applicable only when type parameter is **episode**.</param>
        /// <param name="genreIds">A comma-delimited string of a list of genre ids. You can find the id and the name of all genres from `GET /genres`. It works only when **type** is *episode* or *podcast*.</param>
        /// <param name="publishedBefore">Only show episodes/podcasts/curated lists published before this timestamp (in milliseconds). If **published_before** &amp; **published_after** are used at the same time, **published_before** should be bigger than **published_after**.</param>
        /// <param name="publishedAfter">Only show episodes/podcasts/curated lists published after this timestamp (in milliseconds). If **published_before** &amp; **published_after** are used at the same time, **published_before** should be bigger than **published_after**.</param>
        /// <param name="onlyIn">A comma-delimited string to search only in specific fields. Allowed values are title, description, author, and audio. If not specified, then search every fields.</param>
        /// <param name="language">Limit search results to a specific language. If not specified, it'll be any language. You can get a list of supported languages from `GET /languages`. It works only when **type** is *episode* or *podcast*.</param>
        /// <param name="ocid">A podcast id (the **podcast_id** field in response). This parameter is to limit search results in a specific podcast. It works only when **type** is *episode*.</param>
        /// <param name="ncid">A podcast id (the **podcast_id** field in response). This parameter is to exclude search results from a specific podcast. It works only when **type** is *episode*.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts/episodes with explicit language. 1 is yes and 0 is no. It works only when **type** is *episode* or *podcast*.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        Task<SearchResponse<T>> SearchAsync<T>(string q,
            double? sortByDate = null, 
            int? offset = null, int? lenMin = null, int? lenMax = null, string genreIds = null,
            int? publishedBefore = null, int? publishedAfter = null, string onlyIn = null, string language = null,
            string ocid = null, string ncid = null, double? safeMode = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T:ISearchResult;

        /// <summary>Typeahead search</summary>
        /// <param name="q">Search term, e.g., person, place, topic...</param>
        /// <param name="showPodcasts">Autosuggest podcasts. This only searches podcast title and publisher and returns very limited info of 5 podcasts. 1 is yes, 0 is no. It's a bit slow to autosuggest podcasts, so we turn it off by default. If show_podcasts=1, you can also pass iTunes id (e.g., 474722933) to the q parameter to fetch podcast meta data.</param>
        /// <param name="showGenres">Whether or not to autosuggest genres. 1 is yes, 0 is no.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts/episodes with explicit language. 1 is yes and 0 is no. It works only when **show_podcasts** is *1*.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<TypeaheadResponse> TypeaheadAsync(string q, double? showPodcasts = null,
            double? showGenres = null, double? safeMode = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch a list of best podcasts by genre</summary>
        /// <param name="genreId">You can get the id from `GET /genres`. If not specified, it'll be the overall best podcasts, which can be considered as a special genre.</param>
        /// <param name="page">Page number of those podcasts in this genre.</param>
        /// <param name="region">Filter best podcasts by country/region. You can get the supported country codes from `GET /regions`.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts with explicit language. 1 is yes, and 0 is no.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<BestPodcastsResponse> GetBestPodcastsAsync(string genreId = null, int? page = null,
            string region = null, double? safeMode = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch detailed meta data and episodes for a podcast by id</summary>
        /// <param name="id">Podcast id. You can get podcast id from using other endpoints, e.g., `GET /search`, `GET /best_podcasts`...</param>
        /// <param name="nextEpisodePubDate">For episodes pagination. It's the value of **next_episode_pub_date** from the response of last request. If not specified, just return latest 10 episodes or oldest 10 episodes, depending on the value of the **sort** parameter.</param>
        /// <param name="sort">How do you want to sort the episodes of this podcast?</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<PodcastFull> GetPodcastByIdAsync(string id, int? nextEpisodePubDate = null,
            Sort? sort = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch detailed meta data for an episode by id</summary>
        /// <param name="id">id for a specific episode. You can get episode id from using other endpoints, e.g., `GET /search`...</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<EpisodeFull> GetEpisodeByIdAsync(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Batch fetch basic meta data for episodes</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<GetEpisodesInBatchResponse> GetEpisodesInBatchAsync(Stream body,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Batch fetch basic meta data for podcasts</summary>

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<GetPodcastsInBatchResponse> GetPodcastsInBatchAsync(Stream body = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch a curated list of podcasts by id</summary>
        /// <param name="id">id for a specific curated list of podcasts. You can get the id from the response of `GET /search?type=curated` or `GET /curated_podcasts`.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<CuratedListFull> GetCuratedPodcastByIdAsync(string id,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch a list of podcast genres</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<GetGenresResponse> GetGenresAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch a list of supported countries/regions for best podcasts</summary>

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<GetRegionsResponse> GetRegionsAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch a list of supported languages for podcasts</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<GetLanguagesResponse> GetLanguagesAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch a random podcast episode</summary>

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<EpisodeSimple> JustListenAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch curated lists of podcasts</summary>
        /// <param name="page">Page number of curated lists.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<GetCuratedPodcastsResponse> GetCuratedPodcastsAsync(int? page = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch recommendations for a podcast</summary>
        /// <param name="id">Podcast id.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts with explicit language. 1 is yes, and 0 is no.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<GetPodcastRecommendationsResponse> GetPodcastRecommendationsAsync(string id,
            double? safeMode = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Fetch recommendations for an episode</summary>
        /// <param name="id">Episode id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts with explicit language. 1 is yes, and 0 is no.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        Task<GetEpisodeRecommendationsResponse> GetEpisodeRecommendationsAsync(string id, CancellationToken cancellationToken,
            double? safeMode = null);

        /// <summary>Submit a podcast to Listen Notes database</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<SubmitPodcastResponse> SubmitPodcastAsync(Stream body,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}