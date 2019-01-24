using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class Diversity
    {

        public string DiversityId { get; set; }
        public string CustomerId { get; set; }
        public string ConsentToCollectLLDDHealth { get; set; }
        public string LearningDifficultyOrDisabilityDeclaration { get; set; }
        public string PrimaryLearningDifficultyOrDisability { get; set; }
        public string SecondaryLearningDifficultyOrDisability { get; set; }
        public string DateAndTimeLLDDHealthConsentCollected { get; set; }
        public string ConsentToCollectEthnicity { get; set; }
        public string Ethnicity { get; set; }
        public string DateAndTimeEthnicityCollected { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

    }
}
