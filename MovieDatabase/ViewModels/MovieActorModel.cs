using Caliburn.Micro;
using Newtonsoft.Json;

namespace MovieDatabase.ViewModels
{
    public class MovieActorModel : PersonBaseModel
    {
        public string Character { get; set; }
    }
}