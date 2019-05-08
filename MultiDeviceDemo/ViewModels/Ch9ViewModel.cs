using Microsoft.Toolkit.Parsers.Rss;
using MultiDeviceDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MultiDeviceDemo.ViewModels
{
    public class Ch9ViewModel : INotifyPropertyChanged
    {
        private List<Video> _videos;
        public List<Video> Videos
        {
            get { return _videos;  }
            set
            {
                _videos = value;
                NotifyPropertyChanged(nameof(Videos));
            }
        }

        private Video _selectedVideo;
        public Video SelectedVideo
        {
            get { return _selectedVideo; }
            set
            {
                if(_selectedVideo != value)
                {
                    _selectedVideo = value;
                    NotifyPropertyChanged(nameof(SelectedVideo));
                }
            }
        }

        public async Task LoadFeed()
        {
            string feed = null;

            using (var client = new HttpClient())
            {
                try
                {
                    feed = await client.GetStringAsync("https://s.ch9.ms/Feeds/RSS");
                }
                catch { }
            }

            if (feed != null)
            {
                var parser = new RssParser();
                var rss = parser.Parse(feed);

                List<Video> videos = new List<Video>();

                foreach (var element in rss)
                {
                    videos.Add(new Video()
                    {
                        Summary = element.Summary,
                        Title = element.Title,
                        Author = element.Author,
                        PublishDate = element.PublishDate,
                        ImageUrl = element.ImageUrl
                    });
                }

                Videos = videos.OrderByDescending(v => v.PublishDate).ToList();
                SelectedVideo = Videos.FirstOrDefault();
            }
        }

        private DispatcherTimer _timer;
        public void StartTimer()
        {
            if(_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(5);
                _timer.Tick += _timer_Tick;
            }

            _timer.Start();
        }

        private void _timer_Tick(object sender, object e)
        {
            if(SelectedVideo == null)
            {
                SelectedVideo = Videos.FirstOrDefault();
            } else
            {
                int pos = Videos.IndexOf(SelectedVideo);
                if(pos<Videos.Count - 1)
                {
                    SelectedVideo = Videos[pos + 1];
                } else
                {
                    SelectedVideo = Videos.FirstOrDefault();
                }
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
