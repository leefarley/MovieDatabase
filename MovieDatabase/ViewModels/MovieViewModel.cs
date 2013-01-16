using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MovieDatabase.Services;
using MyToolkit.Multimedia;
using Windows.UI.Xaml.Controls;

namespace MovieDatabase.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        private readonly IMDBService _imdbService;
        public int MovieId { set; get; }

        public MovieViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _imdbService = new IMDBService();
            Loading = true;
        }

        protected override void OnInitialize()
        {
            Populate();
            base.OnInitialize();
        }

        public void ActorSelected(ItemClickEventArgs eventArgs)
        {
            var sample = (PersonBaseModel)eventArgs.ClickedItem;

            NavigationService.UriFor<PersonViewModel>()
                .WithParam(p => p.ActorId, sample.Id)
                .WithParam(p => p.BackgroundImage, _backgroundImage)
                .WithParam(p => p.Name, sample.Name).Navigate();
        }

        public void PlayVideo(ItemClickEventArgs eventArgs)
        {
            NavigationService.UriFor<VideoViewModel>()
                .WithParam(p => p.VideoKey, VideoKey)
                .Navigate();
        }

        private async void Populate()
        {
            MovieModel movie = await _imdbService.GetMovieAsync(MovieId);
            PosterPath = movie.PosterPath;
            Title = movie.Title;
            BackgroundImage = movie.BackgroundPath;
            Overview = movie.Overview;
            ReleaseDate = movie.ReleaseDate.Date.ToString("d MMM yyyy");
            Runtime = movie.Runtime;
            Actors = movie.Casts.Cast;
            Crew = movie.Casts.Crew;
            Budget = movie.Budget;
            Revenue = movie.Revenue;
            Status = movie.Status;
            VideoKey = movie.Trailers.YouTube.First().Source;
            Loading = false;
        }

        #region BackgroundImage
        /// <summary>
        /// Comments
        /// </summary>
        private string _backgroundImage;
        public string BackgroundImage
        {
            get
            {
                string returnUrl = string.Format("http://cf2.imgobject.com/t/p/w780/{0}", _backgroundImage);
                return returnUrl;
            }
            set{ 
                _backgroundImage = value;
                NotifyOfPropertyChange(); 
            }
        } 
        #endregion BackgroundImage
        #region Title
        /// <summary>
        /// Comments
        /// </summary>
        private string _title;
        public string Title
        {
            get{ return _title; }
            set{ _title = value; NotifyOfPropertyChange(); }
        } 
        #endregion Title
        #region Overview
        /// <summary>
        /// Comments
        /// </summary>
        private string _overview;
        public string Overview
        {
            get{ return _overview; }
            set{ _overview = value; NotifyOfPropertyChange(); }
        } 
        #endregion Overview
        #region PosterPath
        /// <summary>
        /// Comments
        /// </summary>
        private string _posterPath;
        public string PosterPath
        {
            get
            {
                string returnUrl = string.Format("http://cf2.imgobject.com/t/p/w500/{0}", _posterPath);
                return returnUrl;
            }
            set
            {
                _posterPath = value; 
                NotifyOfPropertyChange();
            }
        } 
        #endregion PosterPath
        #region ReleaseDate
        /// <summary>
        /// Comments
        /// </summary>
        private string _releaseDate;
        public string ReleaseDate
        {
            get{ return _releaseDate; }
            set{ _releaseDate = value; NotifyOfPropertyChange(); }
        } 
        #endregion ReleaseDate
        #region Runtime
        /// <summary>
        /// Comments
        /// </summary>
        private string _runtime;
        public string Runtime
        {
            get{ return string.Format("{0}m",_runtime); }
            set{ _runtime = value; NotifyOfPropertyChange(); }
        } 
        #endregion Runtime
        #region Budget
        /// <summary>
        /// Comments
        /// </summary>
        private string _budget;
        public string Budget
        {
            get{ return string.Format("${0}",_budget); }
            set{ _budget = value; NotifyOfPropertyChange(); }
        } 
        #endregion Budget
        #region Revenue
        /// <summary>
        /// Comments
        /// </summary>
        private string _revenue;
        public string Revenue
        {
            get{ return string.Format("${0}",_revenue); }
            set{ _revenue = value; NotifyOfPropertyChange(); }
        } 
        #endregion Revenue
        #region Status
        /// <summary>
        /// Comments
        /// </summary>
        private string _status;
        public string Status
        {
            get{ return _status; }
            set{ _status = value; NotifyOfPropertyChange(); }
        } 
        #endregion Status
        #region Actors
        /// <summary>
        /// Comments
        /// </summary>
        private IEnumerable<MovieActorModel> _actors;
        public IEnumerable<MovieActorModel> Actors
        {
            get{ return _actors; }
            set{ _actors = value; NotifyOfPropertyChange(); }
        } 
        #endregion Actors
        #region Crew
        /// <summary>
        /// Comments
        /// </summary>
        private IEnumerable<MovieCrewModel> _crew;
        public IEnumerable<MovieCrewModel> Crew
        {
            get{ return _crew; }
            set{ _crew = value; NotifyOfPropertyChange(); }
        } 
        #endregion Crew

        public string VideoKey { get; set; }


    }
}
