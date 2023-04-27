using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dressing_Room
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
