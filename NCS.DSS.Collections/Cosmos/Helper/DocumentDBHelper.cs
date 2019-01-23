using Microsoft.Azure.Documents.Client;
using System;

namespace NCS.DSS.Collections.Cosmos.Helper
{
    public static class DocumentDBHelper
    {        
        private static Uri _collectionDocumentCollectionUri;
        private static readonly string CollectionDatabaseId = Environment.GetEnvironmentVariable("CollectionDatabaseId");
        private static readonly string CollectionCollectionId = Environment.GetEnvironmentVariable("CollectionCollectionId");        
        
        #region CollectionDB

        public static Uri CreateCollectionDocumentCollectionUri()
        {
            if (_collectionDocumentCollectionUri != null)
                return _collectionDocumentCollectionUri;

            _collectionDocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(
                CollectionDatabaseId, CollectionCollectionId);

            return _collectionDocumentCollectionUri;
        }

        public static Uri CreateCollectionDocumentUri(Guid collectionId)
        {
            return UriFactory.CreateDocumentUri(CollectionDatabaseId, CollectionCollectionId, collectionId.ToString());
        }

        #endregion        
    }
}
