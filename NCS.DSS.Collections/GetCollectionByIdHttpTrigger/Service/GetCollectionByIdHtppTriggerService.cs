﻿using DFC.Functions.DI.Standard.Attributes;
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
        public async Task<Collection> ProcessRequestAsync(Guid touchPointId, Guid collectionId)
        {
            //return await _documentDBProvider.GetCollectionForTouchpointAsync(touchPointId, collectionId);
            return new Collection
            {
                CollectionId = Guid.NewGuid(),
                CollectionReports = new Uri("http://localhost"),
                LastModifiedDate = DateTime.Now,
                TouchPointId = touchPointId,
                UKPRN = "12345678"
            };
        }
    }
}
