using ResponsiveDesign.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace ResponsiveDesign.ViewModels
{
    public class EndGameViewModel : INotifyPropertyChanged
    {
        private Movie _movie;

        public Movie Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                NotifyPropertyChanged(nameof(Movie));
            }
        }

        public void LoadMovie()
        {
            string FilePath = Path.Combine(Package.Current.InstalledLocation.Path, "Data/endgame.json");
            using (StreamReader file = File.OpenText(FilePath))
            {
                var json = file.ReadToEnd();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Movie>(json);
                Movie = result;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
