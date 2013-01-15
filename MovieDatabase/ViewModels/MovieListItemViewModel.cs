using System;
using Caliburn.Micro;
using MovieDatabase.Services;

namespace MovieDatabase.ViewModels
{
    public class MovieListItemViewModel : PropertyChangedBase
    {
        public MovieListItemViewModel(MovieItemModel movieItem)
        {
            Id = movieItem.Id;
            Title = movieItem.Title;
            Poster = movieItem.PosterPath;
        }

        #region Id
        /// <summary>
        /// Comments
        /// </summary>
        private int _id;
        public int Id
        {
            get{ return _id; }
            set{ _id = value; NotifyOfPropertyChange(); }
        } 
        #endregion Id
        #region Poster
        /// <summary>
        /// Comments
        /// </summary>
        private string _poster;
        public string Poster
        {
            get
            {
                string returnUrl = string.Format("http://cf2.imgobject.com/t/p/w185/{0}",_poster);
                return returnUrl;
            }
            set{ _poster = value; NotifyOfPropertyChange(); }
        } 
        #endregion Poster
        #region Title
        /// <summary>
        /// Comments
        /// </summary>
        private string _title;
        public string Title
        {
            get{ return _title; }
            set
            {
                _title = value; 
                NotifyOfPropertyChange();
            }
        } 
        #endregion Title
        #region Released
        /// <summary>
        /// Comments
        /// </summary>
        private DateTime _Released;
        public DateTime Released
        {
            get{ return _Released; }
            set{ _Released = value; NotifyOfPropertyChange(); }
        } 
        #endregion Released
    }
}
