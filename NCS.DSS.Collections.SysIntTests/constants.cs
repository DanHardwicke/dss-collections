using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.SysIntTests
{
    public class constants
    {
        public const string CustomerId = "CustomerId";
        public const string AddressId = "AddressId";
        public const string ContactId = "ContactId";
        public const string InteractionId = "InteractionId";
        public const string SessionId = "SessionId";
        public const string ActionPlanId = "ActionPlanId";
        public const string ActionId = "ActionId";
        public const string OutcomeId = "OutcomeId";

        public const string CustomersPath = "customers/api/customers/";
        public const string AddressesPath = "addresses/api/Customers/CustomerId/addresses/";
        public const string ContactsPath = "contactdetails/api/Customers/CustomerId/contactdetails/";
        public const string InteractionsPath = "interactions/api/Customers/CustomerId/Interactions/";
        public const string SessionsPath = "sessions/api/Customers/CustomerId/Interactions/InteractionId/sessions/";
        public const string ActionPlansPath = "actionplans/api/Customers/CustomerId/Interactions/InteractionId/ActionPlans/";
        public const string ActionsPath = "actions/api/Customers/CustomerId/Interactions/InteractionId/ActionPlans/ActionPlanId/actions/";
        public const string OutcomesPath = "outcomes/api/Customers/CustomerId/Interactions/InteractionId/ActionPlans/ActionPlanId/outcomes/";

        public const string ActionPlansPathV2 = "actionplans/api/Customers/CustomerId/Interactions/InteractionId/Sessions/SessionId/ActionPlans/";
        public const string ActionsPathV2 = "actions/api/Customers/CustomerId/Interactions/InteractionId/Sessions/SessionId/ActionPlans/ActionPlanId/actions/";
        public const string OutcomesPathV2 = "outcomes/api/Customers/CustomerId/Interactions/InteractionId/Sessions/SessionId/ActionPlans/Sessions/SessionId/ActionPlanId/outcomes/";

        public static string BackupTableNameFromId(string primaryKey)
        {
            string returnVal;
            switch (primaryKey)
            {
                case constants.AddressId:
                    returnVal = "dss-Addresses";
                    break;
                default:
                    returnVal = "dss-" + primaryKey.Substring(0, primaryKey.Length - 2) + "s";
                    break;

            }
            return returnVal;

        }

        public static string BackupTableNameFromResource(string resource)
        {
            string returnVal;
            switch (resource)
            {
                case "Address":
                    returnVal = "dss-Addresses";
                    break;
                default:
                    returnVal = "dss-" + resource + "s";
                    break;

            }
            return returnVal;

        }

        public static string CollectionNameFromId(string resource)
        {
            string returnVal;
            switch (resource)
            {
                case "AddressId":
                    returnVal = "addresses";
                    break;
                default:
                    returnVal = resource.Substring(1, resource.Length - 2) + "s";
                    break;

            }
            return returnVal.ToLower();

        }
    }
}
