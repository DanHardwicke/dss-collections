using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class Session
    {

        public string SessionID { get; set; }
        public string CustomerID { get; set; }
        public string InteractionID { get; set; }
        public string DateandTimeOfSession { get; set; }
        public string VenuePostCode { get; set; }
        public string SessionAttended { get; set; }
        public string ReasonForNonAttendance { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointID { get; set; }

    }
}
