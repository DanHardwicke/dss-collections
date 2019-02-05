using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Linq;

namespace NCS.DSS.Collections.SysIntTests.Models
{
    class Customer
    {
        public string CustomerID { get; set; }
        public string DateOfRegistration { get; set; }
        public string Title { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string DateofBirth { get; set; }
        public string Gender { get; set; }
        public string UniqueLearnerNumber { get; set; }
        public string OptInUserResearch { get; set; }
        public string OptInMarketResearch { get; set; }
        public string DateOfTermination { get; set; }
        public string ReasonForTermination { get; set; }
        public string IntroducedBy { get; set; }
        public string IntroducedByAdditionalInfo { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointID { get; set; }
    }
}
