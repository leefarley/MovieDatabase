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
            var sample = (MovieActorModel)eventArgs.ClickedItem;

            NavigationService.UriFor<ActorViewModel>()
                .WithParam(p => p.ActorId, sample.Id)
                .WithParam(p => p.BackgroundImage, _backgroundImage)
                .WithParam(p => p.Name, sample.Name).Navigate();
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
        private int _runtime;
        public int Runtime
        {
            get{ return _runtime; }
            set{ _runtime = value; NotifyOfPropertyChange(); }
        } 
        #endregion Runtime
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


    }
}
