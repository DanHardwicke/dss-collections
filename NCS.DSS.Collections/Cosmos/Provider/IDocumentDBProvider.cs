using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using NCS.DSS.Collections.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.Cosmos.Provider
{
    public interface IDocumentDBProvider
    {
        Task<bool> DoesCollectionResourceExist(Collection collection);
        Task<ResourceResponse<Document>> CreateCollectionAsync(Collection collection);
        Task<List<Collection>> GetCollectionsForTouchpointAsync(Guid touchpointId);
        Task<Collection> GetCollectionForTouchpointAsync(Guid touchPointId, Guid collectionId);
    }
}
