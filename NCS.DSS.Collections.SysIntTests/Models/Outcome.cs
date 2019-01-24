using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class Outcome
    {

        public string OutcomeId { get; set; }
        public string CustomerId { get; set; }
        public string ActionPlanId { get; set; }
        public string OutcomeType { get; set; }
        public string OutcomeClaimedDate { get; set; }
        public string OutcomeEffectiveDate { get; set; }
        public string TouchpointId { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointId { get; set; }


    }
}
