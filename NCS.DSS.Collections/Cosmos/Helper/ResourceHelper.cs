using System;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.Cosmos.Helper
{
    public class ResourceHelper : IResourceHelper
    {
        public bool DoesCollectionBelongToTouchpoint(Guid touchpointId, Guid collectionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesCollectionExist(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
