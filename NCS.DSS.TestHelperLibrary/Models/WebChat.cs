using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.FunctionalTests.Models
{
    class WebChat
    {

        public string WebChatId { get; set; }
        public string CustomerId { get; set; }
        public string InteractionId { get; set; }
        public string DigitalReference { get; set; }
        public string WebChatStartDateandTime { get; set; }
        public string WebChatEndDateandTime { get; set; }
        public string WebChatDuration { get; set; }
        public string WebChatNarrative { get; set; }
        public string SentToCustomer { get; set; }
        public string DateandTimeSentToCustomers { get; set; }
        public string LastModifiedDate { get; set; }
        public string LastModifiedTouchpointId { get; set; }

    }
}
