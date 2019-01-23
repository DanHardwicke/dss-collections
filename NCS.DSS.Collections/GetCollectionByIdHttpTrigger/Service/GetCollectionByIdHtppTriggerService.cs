using DFC.Functions.DI.Standard.Attributes;
using NCS.DSS.Collections.Cosmos.Provider;
using NCS.DSS.Collections.Models;
using System;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.GetCollectionByIdHttpTrigger.Service
{
    public class GetCollectionByIdHtppTriggerService : IGetCollectionByIdHtppTriggerService
    {
        private readonly IDocumentDBProvider _documentDBProvider;
        public GetCollectionByIdHtppTriggerService([Inject]IDocumentDBProvider documentDBProvider)
        {
            _documentDBProvider = documentDBProvider;
        }
        public async Task<Collection> ProcessRequestAsync(Guid touchpointId, Guid collectionId)
        {
            return await _documentDBProvider.GetCollectionForTouchpointAsync(touchpointId, collectionId);
        }
    }
}
