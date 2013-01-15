﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MovieDatabase.Services;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MovieDatabase.ViewModels
{
    public class ActorViewModel : BaseViewModel
    {
        private readonly IMDBService _imdbService;

        public int ActorId { get; set; }

        private string _backgroundImage;
        public string BackgroundImage {
            get { return string.Format("http://cf2.imgobject.com/t/p/w780/{0}", _backgroundImage); }
            set { _backgroundImage = value; NotifyOfPropertyChange(); }
        }

        public ActorViewModel(INavigationService navigationService)
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

        public void MovieSelected(ItemClickEventArgs eventArgs)
        {
            var sample = (CastMovieItemModel)eventArgs.ClickedItem;

            NavigationService.UriFor<MovieViewModel>()
                .WithParam(p => p.MovieId, sample.Id)
                .WithParam(p => p.Title, sample.Title)
                .Navigate();
        }

        private async void Populate()
        {
            ActorModel actor = await _imdbService.GetActorAsync(ActorId);
            Name = actor.Name;
            Biography = actor.Biography;
            ProfileImage = actor.ImagePath;
            AlternateNames = actor.AlternateNames;
            Birthday = actor.Birthday;
            Deathday = actor.Deathday;
            Homepage = actor.Homepage;
            AlsoIn = actor.Credits.Cast;
            Loading = false;
        }

        public int Id { get; set; }

        #region Name
        /// <summary>
        /// Comments
        /// </summary>
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyOfPropertyChange(); }
        }
        #endregion Name
        #region ProfileImage
        /// <summary>
        /// Comments
        /// </summary>
        private string _profileImage;
        public string ProfileImage
        {
            get { return string.Format("http://cf2.imgobject.com/t/p/w185/{0}", _profileImage); }
            set { _profileImage = value; NotifyOfPropertyChange(); }
        }
        #endregion ProfileImage
        #region Biography
        /// <summary>
        /// Comments
        /// </summary>
        private string _biography;
        public string Biography
        {
            get{ return _biography; }
            set{ _biography = value; NotifyOfPropertyChange(); }
        } 
        #endregion Biography
        #region AlternateNames
        /// <summary>
        /// Comments
        /// </summary>
        private IEnumerable<string> _alternateNames;
        public IEnumerable<string> AlternateNames
        {
            get{ return _alternateNames; }
            set{ _alternateNames = value; NotifyOfPropertyChange(); }
        } 
        #endregion AlternateNames
        #region Birthday
        /// <summary>
        /// Comments
        /// </summary>
        private string _birthday;
        public string Birthday
        {
            get{ return _birthday; }
            set{ _birthday = value; NotifyOfPropertyChange(); }
        } 
        #endregion Birthday
        #region Deathday
        /// <summary>
        /// Comments
        /// </summary>
        private string _deathday;
        public string Deathday
        {
            get{ return _deathday; }
            set{ _deathday = value; NotifyOfPropertyChange(); }
        } 
        #endregion Deathday
        #region Homepage
        /// <summary>
        /// Comments
        /// </summary>
        private string _homepage;
        public string Homepage
        {
            get{ return _homepage; }
            set{ _homepage = value; NotifyOfPropertyChange(); }
        } 
        #endregion Homepage
        #region PlaceOfBirth
        /// <summary>
        /// Comments
        /// </summary>
        private string _placeOfBirth;
        public string PlaceOfBirth
        {
            get{ return _placeOfBirth; }
            set{ _placeOfBirth = value; NotifyOfPropertyChange(); }
        } 
        #endregion PlaceOfBirth
        #region AlsoIn
        /// <summary>
        /// Comment
        /// </summary>
        private IEnumerable<CastMovieItemModel> _alsoIn;
        public IEnumerable<CastMovieItemModel> AlsoIn
        {
            get{ return _alsoIn; }
            set{ _alsoIn = value; NotifyOfPropertyChange(); }
        } 
        #endregion AlsoIn
    }
}
