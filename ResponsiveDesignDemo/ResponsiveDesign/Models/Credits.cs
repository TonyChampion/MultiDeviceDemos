using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiveDesign.Models
{
    [DataContract]
    public class Credits
    {
        [DataMember(Name = "cast")]
        public List<Cast> Cast { get; set; }
        public IEnumerable<Cast> OrderedCast
        {
            get
            {
                return Cast.OrderBy(c => c.Order);
            }
        }

    }
}
