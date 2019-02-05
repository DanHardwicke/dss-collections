using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NCS.DSS.TestHelperLibrary.Models
{
    class SearchResponse
    {
        [JsonProperty("@odata.count")]
        public int RecordCount { get; set; }

        [JsonProperty("value")]
        public List<NCS.DSS.TestHelperLibrary.Models.Customer> Results { get; set; }

      
    }
}
