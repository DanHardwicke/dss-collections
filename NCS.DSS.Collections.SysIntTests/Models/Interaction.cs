using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class Interaction
    {

        public string InteractionId { get; set; }
        public string CustomerId { get; set; }
        public string TouchpointId { get; set; }
        public string AdviserDetailsId { get; set; }
        public string DateandTimeOfInteraction { get; set; }
        public string Channel { get; set; }
        public string InteractionType { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointId { get; set; }

    }
}
