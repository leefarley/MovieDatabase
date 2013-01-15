using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Newtonsoft.Json;

namespace MovieDatabase.ViewModels
{
    public abstract class PersonBaseModel : PropertyChangedBase
    {
        public int Id { get; set; }

        #region Name
        /// <summary>
        /// Comments
        /// </summary>
        private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; NotifyOfPropertyChange(); }
        } 
        #endregion Name
        #region ProfileImage
        /// <summary>
        /// Comments
        /// </summary>
        private string _profileImage;
        [JsonProperty("profile_path")]
        public string ProfileImage
        {
            get { return string.Format("http://cf2.imgobject.com/t/p/w185/{0}", _profileImage); }
            set { _profileImage = value; NotifyOfPropertyChange(); }
        }
        #endregion ProfileImage
    }
}
