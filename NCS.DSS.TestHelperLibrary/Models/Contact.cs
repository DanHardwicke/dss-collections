using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NCS.DSS.TestHelperLibrary.Models
{
    class Contact
    {
        public string ContactId { get; set; }
        public string CustomerId { get; set; }
        public string PreferredContactMethod { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public string AlternativeNumber { get; set; }
        public string EmailAddress { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointId { get; set; }

    }
}
