using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.TestHelperLibrary.Models
{
    interface ILoader
    {
        string LoaderRef { get; set; }
        //string CustomerId { get; set; }
        string ParentRef { get; set; }
       // string InteractionRef { get; set; }
        //Dictionary<string, string> ParentIds { get; set; }
    }
}
