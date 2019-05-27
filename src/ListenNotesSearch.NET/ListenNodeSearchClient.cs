using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ListenNotesSearch.NET.Models;
using Newtonsoft.Json;
using RestSharp;
using Type = ListenNotesSearch.NET.Models.Type;

namespace ListenNotesSearch.NET
{
    public class ListenNodeSearchClient : IListenNodeSearchClient
    {
        private readonly RestClient _client;
        private readonly string _listenNodeApiKey;
        private readonly Lazy<JsonSerializerSettings> _settings;
        public ListenNodeSearchClient(string listenNodeApiKey)
        {
            _client = new RestClient(BaseUrl);
            _listenNodeApiKey = listenNodeApiKey ?? throw new ArgumentNullException(nameof(listenNodeApiKey));
            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                return settings;
            });
        }

        public Uri BaseUrl { get; } = new Uri("https://listen-api.listennotes.com/api/v2");

        protected JsonSerializerSettings JsonSerializerSettings => _settings.Value;
        
        /// <summary>Fetch a list of best podcasts by genre</summary>
        /// <param name="genreId">You can get the id from `GET /genres`. If not specified, it'll be the overall best podcasts, which can be considered as a special genre.</param>
        /// <param name="page">Page number of those podcasts in this genre.</param>
        /// <param name="region">Filter best podcasts by country/region. You can get the supported country codes from `GET /regions`.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts with explicit language. 1 is yes, and 0 is no.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<BestPodcastsResponse> GetBestPodcastsAsync(string genreId = null,
            int? page = null, string region = null, double? safeMode = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var queryParams = new Dictionary<string, object>();
            if (genreId != null)
            {
                queryParams.Add("genre_id", genreId);
            }

            if (page != null)
            {
                queryParams.Add("page", page);
            }

            if (region != null)
            {
                queryParams.Add("region", region);
            }

            if (safeMode != null)
            {
                queryParams.Add("safe_mode", safeMode);
            }

            var request = CreateRequest("best_podcasts", queryParams);

            return await SendAndProcessRequest<BestPodcastsResponse>(cancellationToken, request);

        }
        /// <summary>Fetch a curated list of podcasts by id</summary>
        /// <param name="id">id for a specific curated list of podcasts. You can get the id from the response of `GET /search?type=curated` or `GET /curated_podcasts`.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<CuratedListFull> GetCuratedPodcastByIdAsync(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var request = CreateRequest($"curated_podcasts/{id}");
            return await SendAndProcessRequest<CuratedListFull>(cancellationToken, request);

        }

        /// <summary>Fetch curated lists of podcasts</summary>
        /// <param name="page">Page number of curated lists.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<GetCuratedPodcastsResponse> GetCuratedPodcastsAsync(int? page = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var queryParams = new Dictionary<string, object>();
            if (page != null)
            {
                queryParams.Add("curated_podcasts", page);
            }
            var request = CreateRequest("curated_podcasts", queryParams);
            return await SendAndProcessRequest<GetCuratedPodcastsResponse>(cancellationToken, request);

        }
        
        /// <summary>Fetch detailed meta data for an episode by id</summary>
        /// <param name="id">id for a specific episode. You can get episode id from using other endpoints, e.g., `GET /search`...</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<EpisodeFull> GetEpisodeByIdAsync(string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var request = CreateRequest($"episodes/{id}");
            return await SendAndProcessRequest<EpisodeFull>(cancellationToken, request);
        }
        
        /// <summary>Fetch recommendations for an episode</summary>
        /// <param name="id">Episode id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts with explicit language. 1 is yes, and 0 is no.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async Task<GetEpisodeRecommendationsResponse> GetEpisodeRecommendationsAsync(
            string id, CancellationToken cancellationToken = default(CancellationToken), double? safeMode = null)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var queryParams = new Dictionary<string, object>();
            if (safeMode != null)
            {
                queryParams.Add("safe_mode", safeMode);
            }

            var request = CreateRequest($"episodes/{id}/recommendations", queryParams);
            return await SendAndProcessRequest<GetEpisodeRecommendationsResponse>(cancellationToken, request);

        }
        
        /// <summary>Batch fetch basic meta data for episodes</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<GetEpisodesInBatchResponse> GetEpisodesInBatchAsync(Stream body,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = CreateRequest("episodes");
            return await SendAndProcessRequest<GetEpisodesInBatchResponse>(cancellationToken, request);

        }
        
        /// <summary>Fetch a list of podcast genres</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<GetGenresResponse> GetGenresAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = CreateRequest("genres");
            return await SendAndProcessRequest<GetGenresResponse>(cancellationToken, request);
        }

        /// <summary>Fetch a list of supported languages for podcasts</summary>
        /// <summary>Fetch a list of supported countries/regions for best podcasts</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<GetLanguagesResponse> GetLanguagesAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = CreateRequest("languages");
            return await SendAndProcessRequest<GetLanguagesResponse>(cancellationToken, request);
        }
        
        /// <summary>Fetch detailed meta data and episodes for a podcast by id</summary>
        /// <param name="id">Podcast id. You can get podcast id from using other endpoints, e.g., `GET /search`, `GET /best_podcasts`...</param>
        /// <param name="nextEpisodePubDate">For episodes pagination. It's the value of **next_episode_pub_date** from the response of last request. If not specified, just return latest 10 episodes or oldest 10 episodes, depending on the value of the **sort** parameter.</param>
        /// <param name="sort">How do you want to sort the episodes of this podcast?</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<PodcastFull> GetPodcastByIdAsync(string id,
            int? nextEpisodePubDate = null, Sort? sort = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var queryParams = new Dictionary<string, object>();
            if (nextEpisodePubDate != null)
            {
                queryParams.Add("next_episode_pub_date", nextEpisodePubDate);
            }

            if (sort != null)
            {
                queryParams.Add("sort", nextEpisodePubDate);
            }

            var request = CreateRequest($"podcast/{id}", queryParams);
            return await SendAndProcessRequest<PodcastFull>(cancellationToken, request);
        }
        
        /// <summary>Fetch recommendations for a podcast</summary>
        /// <param name="id">Podcast id.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts with explicit language. 1 is yes, and 0 is no.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<GetPodcastRecommendationsResponse> GetPodcastRecommendationsAsync(
            string id, double? safeMode = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var queryParams = new Dictionary<string, object>();
            if (safeMode != null)
            {
                queryParams.Add("safe_mode", safeMode);
            }
            var request = CreateRequest($"podcasts/{id}/recommendations", queryParams);
            return await SendAndProcessRequest<GetPodcastRecommendationsResponse>(cancellationToken, request);

        }
        
        /// <summary>Batch fetch basic meta data for podcasts</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<GetPodcastsInBatchResponse> GetPodcastsInBatchAsync(Stream body = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = CreateRequest("podcasts");
            return await SendAndProcessRequest<GetPodcastsInBatchResponse>(cancellationToken, request);
        }

        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<GetRegionsResponse> GetRegionsAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = CreateRequest("regions");
            return await SendAndProcessRequest<GetRegionsResponse>(cancellationToken, request);
        }
        
        /// <summary>Fetch a random podcast episode</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<EpisodeSimple> JustListenAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = CreateRequest("just_listen");
            return await SendAndProcessRequest<EpisodeSimple>(cancellationToken, request);
        }

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
        public async Task<SearchResponse> SearchAsync(string q,
            double? sortByDate = null,
            Type? type = null, int? offset = null, int? lenMin = null, int? lenMax = null, string genreIds = null,
            int? publishedBefore = null, int? publishedAfter = null, string onlyIn = null, string language = null,
            string ocid = null, string ncid = null, double? safeMode = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (q == null)
                throw new ArgumentNullException(nameof(q));
            var queryParams = new Dictionary<string, object> { { "q", q } };
            if (sortByDate != null)
            {
                queryParams.Add("sort_by_date", sortByDate);
            }
            if (type != null)
            {
                queryParams.Add("type", type);
            }
            if (offset != null)
            {
                queryParams.Add("offset", offset);
            }
            if (lenMin != null)
            {
                queryParams.Add("len_min", lenMin);
            }
            if (lenMax != null)
            {
                queryParams.Add("len_max", lenMax);
            }
            if (genreIds != null)
            {
                queryParams.Add("genre_ids", genreIds);
            }
            if (publishedBefore != null)
            {
                queryParams.Add("published_before", publishedBefore);
            }
            if (publishedAfter != null)
            {
                queryParams.Add("published_after", publishedAfter);
            }
            if (onlyIn != null)
            {
                queryParams.Add("only_in", onlyIn);
            }
            if (language != null)
            {
                queryParams.Add("language", language);
            }
            if (ocid != null)
            {
                queryParams.Add("ocid", ocid);
            }
            if (ncid != null)
            {
                queryParams.Add("ncid", ncid);
            }
            if (safeMode != null)
            {
                queryParams.Add("safe_mode", safeMode);
            }

            var request = CreateRequest("search", queryParams);

            return await SendAndProcessRequest<SearchResponse>(cancellationToken, request);
        }
        
        /// <summary>Submit a podcast to Listen Notes database</summary>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<SubmitPodcastResponse> SubmitPodcastAsync(Stream body,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = CreateRequest("podcasts/submit");
            return await SendAndProcessRequest<SubmitPodcastResponse>(cancellationToken, request);
        }
        
        /// <summary>Typeahead search</summary>
        /// <param name="q">Search term, e.g., person, place, topic...</param>
        /// <param name="showPodcasts">Autosuggest podcasts. This only searches podcast title and publisher and returns very limited info of 5 podcasts. 1 is yes, 0 is no. It's a bit slow to autosuggest podcasts, so we turn it off by default. If show_podcasts=1, you can also pass iTunes id (e.g., 474722933) to the q parameter to fetch podcast meta data.</param>
        /// <param name="showGenres">Whether or not to autosuggest genres. 1 is yes, 0 is no.</param>
        /// <param name="safeMode">Whether or not to exclude podcasts/episodes with explicit language. 1 is yes and 0 is no. It works only when **show_podcasts** is *1*.</param>
        /// <returns>OK</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<TypeaheadResponse> TypeaheadAsync(string q, double? showPodcasts = null,
            double? showGenres = null, double? safeMode = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (q == null)
                throw new ArgumentNullException("q");
            var queryParams = new Dictionary<string, object>();
            queryParams.Add("q", q);
            if (showPodcasts != null)
            {
                queryParams.Add("q", showPodcasts);
            }
            if (showGenres != null)
            {
                queryParams.Add("show_genres", showGenres);
            }
            if (safeMode != null)
            {
                queryParams.Add("safe_mode", safeMode);
            }
            var request = CreateRequest("typeahead", queryParams);

            return await SendAndProcessRequest<TypeaheadResponse>(cancellationToken, request);
        }

        private static T CheckStatusResponse<T>(IRestResponse<T> response)
        {
            var status = ((int)response.StatusCode).ToString();
            if (status == "200")
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }

            var errorStr = string.Empty;
            switch (status)
            {
                case "401":
                    {
                        errorStr = "Wrong api key or your account is suspended";
                        break;
                    }
                case "429":
                    {

                        errorStr = "You are using FREE plan and you exceed the quota limit";
                        break;
                    }
                case "5XX":
                    {

                        errorStr = "Unexpected server errors";
                        break;
                    }
                default:
                    {
                        if (status != "200" && status != "204")
                        {
                            errorStr =
                                "The HTTP status code of the response was not expected (" + (int)response.StatusCode +
                                ").";
                        }

                        break;
                    }
            }
            throw new SwaggerException(errorStr, (int)response.StatusCode, response.Content, response.Headers, null);
        }

        private string BuildParameterQueryString(string parameterName, object parameterValue)
        {
            var sb = new StringBuilder(parameterName);
            sb.Append("=")
              .Append(Uri.EscapeDataString(ConvertToString(parameterValue, CultureInfo.InvariantCulture)))
              .Append("&");
            return sb.ToString();
        }

        private string ConvertToString(object value, CultureInfo cultureInfo)
        {
            switch (value)
            {
                case Enum _:
                    {
                        var name = Enum.GetName(value.GetType(), value);
                        if (name != null)
                        {
                            var field = value.GetType().GetTypeInfo().GetDeclaredField(name);
                            if (field != null)
                            {
                                if (field.GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                                {
                                    return attribute.Value ?? name;
                                }
                            }
                        }
                        break;
                    }

                case bool _:
                    return Convert.ToString(value, cultureInfo)?.ToLowerInvariant();
                case byte[] bytes:
                    return Convert.ToBase64String(bytes);
                default:
                    {
                        if (value != null && value.GetType().IsArray)
                        {
                            var array = ((Array)value).OfType<object>();
                            return string.Join(",", array.Select(o => ConvertToString(o, cultureInfo)));
                        }
                        break;
                    }
            }
            return Convert.ToString(value, cultureInfo);
        }

        private RestRequest CreateRequest(string resource, Dictionary<string, object> queryParams)
        {
            var nvc = new Dictionary<string, string>();
            if (queryParams == null) throw new ArgumentNullException(nameof(queryParams));
            foreach (var queryParam in queryParams)
            {
                nvc.Add(queryParam.Key, ConvertToString(queryParam.Value, CultureInfo.InvariantCulture));
            }
            return CreateRequest(resource, nvc);
        }

        private RestRequest CreateRequest(string resource, Dictionary<string,string> queryParams = null)
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("X-ListenAPI-Key",
                ConvertToString(_listenNodeApiKey, CultureInfo.InvariantCulture));
            request.AddHeader("Accept", "application/json");
            if (queryParams != null)
            {
                foreach (var queryParam in queryParams)
                {
                    request.AddParameter(queryParam.Key,
                        ConvertToString(queryParam.Value, CultureInfo.InvariantCulture));
                }
            }
            return request;
        }

        private void PrepareRequest(HttpRequestMessage request, string url) { }
        private void PrepareRequest(HttpClient client, HttpRequestMessage request) { }
        private void ProcessResponse(HttpResponseMessage response) { }

        private async Task<T> SendAndProcessRequest<T>(CancellationToken cancellationToken, RestRequest request)
        {
            var response = await _client.ExecuteTaskAsync<T>(request, cancellationToken)
                .ConfigureAwait(false);
            return CheckStatusResponse(response);
        }
    }
}