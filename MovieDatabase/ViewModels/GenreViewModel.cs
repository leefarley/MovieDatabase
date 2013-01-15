using Caliburn.Micro;

namespace MovieDatabase.ViewModels
{
    public class GenreViewModel : PropertyChangedBase
    {
        private int Id { get; set; }
        #region Name
        /// <summary>
        /// Name
        /// </summary>
        private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; NotifyOfPropertyChange(); }
        } 
        #endregion Name
    }
}