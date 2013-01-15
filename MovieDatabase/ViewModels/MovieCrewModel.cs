using Caliburn.Micro;
using Newtonsoft.Json;

namespace MovieDatabase.ViewModels
{
    public class MovieCrewModel : PersonBaseModel
    {
        #region Department
        /// <summary>
        /// Comments
        /// </summary>
        private string _department;
        public string Department
        {
            get{ return _department; }
            set{ _department = value; NotifyOfPropertyChange(); }
        } 
        #endregion Department
        #region Job
        /// <summary>
        /// Comments
        /// </summary>
        private string _job;
        public string Job
        {
            get{ return _job; }
            set{ _job = value; NotifyOfPropertyChange(); }
        } 
        #endregion Job
    }
}