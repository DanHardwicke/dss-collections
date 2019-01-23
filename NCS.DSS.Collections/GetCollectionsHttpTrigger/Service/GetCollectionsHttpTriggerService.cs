using NCS.DSS.Collections.Cosmos.Provider;
using NCS.DSS.Collections.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.GetCollectionsHttpTrigger.Service
{
    public class GetCollectionsHttpTriggerService : IGetCollectionsHttpTriggerService
    {
        private readonly IDocumentDBProvider _documentDBProvider;        
        public GetCollectionsHttpTriggerService(IDocumentDBProvider documentDBProvider)
        {
            _documentDBProvider = documentDBProvider;
        }
        public async Task<List<Collection>> ProcessRequestAsync(Guid touchpointId)
        {
            return await _documentDBProvider.GetCollectionsForTouchpointAsync(touchpointId);
        }
    }
}
