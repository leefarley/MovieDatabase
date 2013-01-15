using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MovieDatabase.Services;
using Windows.UI.Xaml.Controls;

namespace MovieDatabase.ViewModels
{
    public class MovieListViewModel : BaseViewModel
    {

        private readonly IMDBService _imdbService;
        public MovieListViewModel(INavigationService navigationService) : base(navigationService)
        {
            _imdbService = new IMDBService();
            
            Populate();
        }

        public void MovieSelected(ItemClickEventArgs eventArgs)
        {
            var sample = (MovieListItemViewModel)eventArgs.ClickedItem;

            NavigationService.UriFor<MovieViewModel>()
                .WithParam(p => p.MovieId, sample.Id)
                .WithParam(p => p.Title, sample.Title).Navigate();
        }

        public async void Populate()
        {
            MovieListModel movieList = await _imdbService.GetMoviesInTheatersAsync();
            Results = movieList.Results.Select(m => new MovieListItemViewModel(m));
            Page = movieList.Page;
            TotalPages = movieList.TotalPages;
            TotalResults = movieList.TotalResults;
        }

        #region Page
        /// <summary>
        /// Comments
        /// </summary>
        private int _page;
        public int Page
        {
            get { return _page; }
            set { _page = value; NotifyOfPropertyChange(); }
        }
        #endregion Page
        #region Results
        /// <summary>
        /// comment
        /// </summary>
        private IEnumerable<MovieListItemViewModel> _results;
        public IEnumerable<MovieListItemViewModel> Results
        {
            get{ return _results; }
            set{ _results = value; NotifyOfPropertyChange(); }
        } 
        #endregion Results
        #region TotalPages

        /// <summary>
        /// Comments
        /// </summary>
        private int _totalPages;
        public int TotalPages
        {
            get{ return _totalPages; }
            set{ _totalPages = value; NotifyOfPropertyChange(); }
        } 
        #endregion TotalPages
        #region TotalResults
        /// <summary>
        /// Comments
        /// </summary>
        private int _totalResults;
        public int TotalResults
        {
            get{ return _totalResults; }
            set{ _totalResults = value; NotifyOfPropertyChange(); }
        } 
        #endregion TotalResults
    }
}
