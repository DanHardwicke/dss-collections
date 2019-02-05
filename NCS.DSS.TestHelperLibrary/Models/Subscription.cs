using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class Subscription
    {

        public string SubscriptionId { get; set; }
        public string CustomerId { get; set; }
        public string TouchPointId { get; set; }
        public string Subscribe { get; set; } 
        public string LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

    }
}
