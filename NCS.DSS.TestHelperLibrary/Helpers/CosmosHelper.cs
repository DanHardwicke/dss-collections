﻿using System;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.TestHelperLibrary.Helpers
{
    public static class CosmosHelper
    {
        //Reusable instance of DocumentClient which represents the connection to a DocumentDB endpoint
        private static DocumentClient client;
        public static string BaseUrl { get; set; }
        public static string AutorizationKey { get; set; }

        public static bool Initialise(string baseUrl, string authKey)
        {
            try
            {
                client = new DocumentClient(new Uri(baseUrl), authKey);
                return true;
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            return false;
        }

        public static bool DeleteDocument( string database, string collection, string id)
        {
            try
            {
                client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(database, collection, id)).GetAwaiter().GetResult();
                return true;
            }
            catch (DocumentClientException de)
            {   
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            return false;
        }
    }
}