using System;
using Caliburn.Micro;
using MovieDatabase.Common;
using MyToolkit.Multimedia;

namespace MovieDatabase.ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        public string VideoKey { get; set; }

        public VideoViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        protected override void OnInitialize()
        {
            Populate();
            Loading = true;
        }

        private async void Populate()
        {
            var titleResponse = await YouTube.GetVideoTitleAsync(VideoKey);
            Title = titleResponse;
            var response = await YouTube.GetVideoUriAsync(VideoKey);
            SourceUrl = response.Uri;
            Loading = false;
        }

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

        #region SourceUrl
        /// <summary>
        /// Comments
        /// </summary>
        private Uri _sourceUrl;
        public Uri SourceUrl
        {
            get{ return _sourceUrl; }
            set
            {
                _sourceUrl = value; 
                NotifyOfPropertyChange();
            }
        } 
        #endregion SourceUrl

    }
}
