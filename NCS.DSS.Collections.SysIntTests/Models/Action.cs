using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class Action
    {

        public string ActionId { get; set; }
        public string CustomerId { get; set; }
        public string ActionPlanId { get; set; }
        public string DateActionAgreed { get; set; }
        public string DateActionAimsToBeCompletedBy { get; set; }
        public string ActionSummary { get; set; }
        public string SignpostedTo { get; set; }
        public string ActionType { get; set; }
        public string ActionStatus { get; set; }
        public string PersonResponsible { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointId { get; set; }

    }
}
