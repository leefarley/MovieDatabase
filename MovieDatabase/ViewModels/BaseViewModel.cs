using Caliburn.Micro;
using Windows.UI.Xaml;

namespace MovieDatabase.ViewModels
{
    public class BaseViewModel : Screen 
    {
        protected readonly INavigationService NavigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void GoBack()
        {
            NavigationService.GoBack();
        }

        public bool CanGoBack
        {
            get { return NavigationService.CanGoBack; }
        }

        #region Loading
        /// <summary>
        /// Comments
        /// </summary>
        private bool _loading;
        public bool Loading
        {
            get { return _loading; }
            set { _loading = value; NotifyOfPropertyChange(); NotifyOfPropertyChange(() => Visibility); }
        }
        #endregion Loading
        #region Visibility
        /// <summary>
        /// Comments
        /// </summary>
        public Visibility Visibility
        {
            get { return (_loading) ? Visibility.Collapsed : Visibility.Visible; }
        }
        #endregion Visibility
    }
}
