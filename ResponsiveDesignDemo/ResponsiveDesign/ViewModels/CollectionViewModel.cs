using ResponsiveDesign.Data;
using ResponsiveDesign.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveDesign.ViewModels
{
    public class CollectionViewModel : INotifyPropertyChanged
    {
        private List<Movie> _movies;

        public List<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                NotifyPropertyChanged(nameof(Movies));
            }
        }

        public async void LoadMovies()
        {
            var uri = "https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=en-US";

            WebClient client = new WebClient();

            List<Movie> movies = new List<Movie>();

            foreach(var movie in MovieIds.Ids)
            {
                var json = await client.DownloadStringTaskAsync(string.Format(uri,movie, MovieIds.Key));
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Movie>(json);
                movies.Add(result);
            }

            Movies = movies.OrderByDescending(m => m.ReleaseDate).ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
