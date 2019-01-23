using System;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.Cosmos.Helper
{
    public interface IResourceHelper
    {
        Task<bool> DoesCollectionExist(Guid customerId);        
        bool DoesCollectionBelongToTouchpoint(Guid touchpointId, Guid collectionId);        
    }
}
