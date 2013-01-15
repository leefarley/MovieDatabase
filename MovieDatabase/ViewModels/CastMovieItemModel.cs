using Newtonsoft.Json;
using Caliburn.Micro;

namespace MovieDatabase.ViewModels
{
    public class CastMovieItemModel : PropertyChangedBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonProperty("poster_path")]
        #region PosterPath
        private string _posterPath;
        public string PosterPath
        {
            get
            {
                string returnUrl = string.Format("http://cf2.imgobject.com/t/p/w185/{0}", _posterPath);
                return returnUrl;
            }
            set{ _posterPath = value; NotifyOfPropertyChange(); }
        }


        #endregion PosterPath
        public string Character { get; set; }
    }
}