using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveDesign.Models
{
    [DataContract]
    public class Cast
    {
        [DataMember(Name = "cast_id")]
        public int CastId { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "character")]
        public string Character { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "profile_path")]
        public string ProfilePath { get; set; }
        [DataMember(Name = "order")]
        public int Order { get; set; }
        public string FullProfilePath {  get
            {
                return String.Format("https://image.tmdb.org/t/p/w500{0}", ProfilePath);
            } }
    }
}
