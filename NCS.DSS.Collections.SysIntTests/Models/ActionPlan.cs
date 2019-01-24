using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class ActionPlan
    {

        public string ActionPlanId { get; set; }
        public string CustomerId { get; set; }
        public string InteractionId { get; set; }
        public string DateActionPlanCreated { get; set; }
        public string CustomerCharterShownToCustomer { get; set; }
        public string DateAndTimeCharterShown { get; set; }
        public string DateActionPlanSentToCustomer { get; set; }
        public string ActionPlanDeliveryMethod { get; set; }
        public string DateActionPlanAcknowledged { get; set; }
        public string PriorityCustomer { get; set; }
        public string CurrentSituation { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointId { get; set; }

    }
}
