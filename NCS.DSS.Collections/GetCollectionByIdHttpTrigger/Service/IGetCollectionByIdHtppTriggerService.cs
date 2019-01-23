using NCS.DSS.Collections.Models;
using System;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.GetCollectionByIdHttpTrigger.Service
{
    public interface IGetCollectionByIdHtppTriggerService
    {
        Task<Collection> ProcessRequestAsync(Guid touchpointId, Guid collectionId);
    }
}
