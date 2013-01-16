using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using MovieDatabase.ViewModels;
using Newtonsoft.Json;

namespace MovieDatabase.Services
{
    public class IMDBService
    {
        private readonly HttpClient _httpClient;

        private const string apiKey = "f1a29ea43ef9e2c1c4014725e314eb4c";

        public IMDBService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IList<GenreViewModel>> GetGenreListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format("genre/list?api_key={0}", apiKey));

            string responseMessage = await response.Content.ReadAsStringAsync();

            GenreListModel genres = JsonConvert.DeserializeObject<GenreListModel>(responseMessage);
            return genres.Genres.ToList();
        }

        public async Task<MovieModel> GetMovieAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format("movie/{0}?api_key={1}&append_to_response=casts,trailers", id, apiKey));
            MovieModel movie = JsonConvert.DeserializeObject<MovieModel>(await response.Content.ReadAsStringAsync());
            return movie;
        }

        public async Task<MovieListModel> GetUpcomingMoviesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format("movie/upcoming?api_key={0}", apiKey));
            MovieListModel movies = JsonConvert.DeserializeObject<MovieListModel>(await response.Content.ReadAsStringAsync());
            return movies;
        }

        public async Task<MovieListModel> GetMoviesInTheatersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format("movie/now_playing?api_key={0}", apiKey));
            MovieListModel movies = JsonConvert.DeserializeObject<MovieListModel>(await response.Content.ReadAsStringAsync());
            return movies;
        }

        public async Task<PersonModel> GetPersonAsync(int actorId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format("person/{0}?api_key={1}&append_to_response=credits", actorId, apiKey));
            string responseMessage = await response.Content.ReadAsStringAsync();
            PersonModel movie = JsonConvert.DeserializeObject<PersonModel>(responseMessage);
            return movie;
        }

        public async Task<MovieListModel> GetMovieSearch(string parameter)
        {
            string requestUrl = string.Format("search/movie?api_key={0}&query={1}", apiKey, parameter); 
            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
            string responseMessage = await response.Content.ReadAsStringAsync();
            MovieListModel movies = JsonConvert.DeserializeObject<MovieListModel>(responseMessage);
            return movies;
        }
    }

    public class GenreListModel
    {
        public IEnumerable<GenreViewModel> Genres { get; set; }
    }

    public class MovieListModel
    {
        public IEnumerable<MovieItemModel> Results { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }

    public class MovieItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        public string Character { get; set; }
    }

    public class MovieModel
    {
        public string Title { get; set; }
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        [JsonProperty("backdrop_path")]
        public string BackgroundPath { get; set; }
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string Runtime { get; set; }
        public MovieCastModel Casts { get; set; }
        public string Budget { get; set; }
        public string Revenue { get; set; }
        public string Status { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }

        public TrailersModel Trailers { get; set; }
    }

    public class MovieCastModel
    {
        public IEnumerable<MovieActorModel> Cast { get; set; }
        public IEnumerable<MovieCrewModel> Crew { get; set; }
    }

    public class PersonModel
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Birthday { get; set; }
        public string Deathday { get; set; }
        public string Homepage { get; set; }
        [JsonProperty("also_known_as")]
        public IEnumerable<string> AlternateNames { get; set; }
        [JsonProperty("profile_path")]
        public string ImagePath { get; set; }
        public CreditsModel Credits { get; set; }
    }

    public class CreditsModel
    {
        public IEnumerable<CastMovieItemModel> Cast { get; set; }
        public IEnumerable<CastMovieItemModel> Crew { get; set; }
    }

    public class TrailersModel
    {
        public ICollection<VideosModel> YouTube { get; set; }
    }

    public class VideosModel
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Size { get; set; }
    }
}
