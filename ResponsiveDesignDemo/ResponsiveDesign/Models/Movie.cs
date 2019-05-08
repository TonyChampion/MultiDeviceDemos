using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveDesign.Models
{
    [DataContract]
    public class Movie
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "overview")]
        public string Overview { get; set; }
        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }
        [DataMember(Name = "release_date")]
        public DateTime ReleaseDate { get; set; }
        [DataMember(Name = "runtime")]
        public int RunTime { get; set; }
        [DataMember(Name = "credits")]
        public Credits Credits { get; set; }
        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        public string FullPosterPath {  get
            {
                return String.Format("https://image.tmdb.org/t/p/w500{0}", PosterPath);

               // return "/Assets/local/" + PosterPath;
            }
        }
    }
}
