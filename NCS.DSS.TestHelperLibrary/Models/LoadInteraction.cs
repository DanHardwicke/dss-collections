using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.TestHelperLibrary.Models
{ 
    class LoadInteraction : Interaction, ILoader
    {
        public string LoaderRef { get; set; }
        public string ParentRef { get; set; }
    }
}
