using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class Goal
    {

        public string GoalId { get; set; }
        public string CustomerId { get; set; }
        public string ActionPlanId { get; set; }
        public string DateGoalCaptured { get; set; }
        public string DateGoalShouldBeCompletedBy { get; set; }
        public string DateGoalAchieved { get; set; }
        public string GoalSummary { get; set; }
        public string GoalType { get; set; }
        public string GoalStatus { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

    }
}
