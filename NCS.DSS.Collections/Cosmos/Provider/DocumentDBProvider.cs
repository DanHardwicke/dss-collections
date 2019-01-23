using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using NCS.DSS.Collections.Cosmos.Client;
using NCS.DSS.Collections.Cosmos.Helper;
using NCS.DSS.Collections.Models;

namespace NCS.DSS.Collections.Cosmos.Provider
{
    public class DocumentDBProvider : IDocumentDBProvider
    {
        public async Task<ResourceResponse<Document>> CreateCollectionAsync(Collection collection)
        {
            var collectionUri = DocumentDBHelper.CreateCollectionDocumentCollectionUri();

            var client = DocumentDBClient.CreateDocumentClient();

            if (client == null)
                return null;

            return await client.CreateDocumentAsync(collectionUri, collection);            
        }

        public async Task<bool> DoesCollectionResourceExist(Collection collection)
        {
            var documentUri = DocumentDBHelper.CreateCollectionDocumentUri(collection.CollectionId);

            var client = DocumentDBClient.CreateDocumentClient();

            if (client == null)
                return false;
            try
            {                
                var response = await client.ReadDocumentAsync(documentUri);
                if (response.Resource != null)
                    return true;
            }
            catch (DocumentClientException)
            {
                return false;
            }

            return false;
        }

        public async Task<Collection> GetCollectionForTouchpointAsync(Guid touchPointId, Guid collectionId)
        {
            var collectionUri = DocumentDBHelper.CreateCollectionDocumentCollectionUri();

            var client = DocumentDBClient.CreateDocumentClient();

            var collectionForTouchpointQuery = client
                ?.CreateDocumentQuery<Collection>(collectionUri, new FeedOptions { MaxItemCount = 1 })
                .Where(x => x.TouchPointId == touchPointId && x.CollectionId == collectionId)
                .AsDocumentQuery();

            if (collectionForTouchpointQuery == null)
                return null;

            var collections = await collectionForTouchpointQuery.ExecuteNextAsync<Collection>();

            return collections?.FirstOrDefault();
        }

        public async Task<List<Collection>> GetCollectionsForTouchpointAsync(Guid touchpointId)
        {
            var collectionUri = DocumentDBHelper.CreateCollectionDocumentCollectionUri();

            var client = DocumentDBClient.CreateDocumentClient();

            var collectionsQuery = client.CreateDocumentQuery<Collection>(collectionUri)
                .Where(so => so.TouchPointId == touchpointId).AsDocumentQuery();

            var collections = new List<Collection>();

            while (collectionsQuery.HasMoreResults)
            {
                var response = await collectionsQuery.ExecuteNextAsync<Collection>();
                collections.AddRange(response);
            }

            return collections.Any() ? collections : null;
        }
    }
}
