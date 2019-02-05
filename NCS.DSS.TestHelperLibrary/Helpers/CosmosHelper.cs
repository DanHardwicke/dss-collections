using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Configuration;





namespace NCS.DSS.TestHelperLibrary.Helpers
{
    public class CosmosHelper
    {

        //Reusable instance of DocumentClient which represents the connection to a DocumentDB endpoint
        private static DocumentClient client;
        public string BaseUrl { get; set; }
        public string AutorizationKey { get; set; }

        public async Task DeleteDocument( string collection, string id)
        {
            try
            {
                // using (client = new DocumentClient(new Uri(BaseUrl + "/" + collection), AutorizationKey))
                using (client = new DocumentClient(new Uri("https://dss-test-shared-cdb.documents.azure.com:443"), "fu2H1i0FXvGXgYj4d6AOQx6Ew2CIXCPdqbUhZH5txN9pO6V8WdD7AxXt2dg5ZfOmTnkx5f7Gujq7zgJcB7eSJA=="))
                {

                    // var response = client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId, "POCO3"));
                    try
                    {
                        var databases = await client.ReadDatabaseFeedAsync();

                        Console.WriteLine("\n4. Reading all databases resources for an account");

                        foreach (var db in databases)

                        {

                            Console.WriteLine(db);

                        }

                    }
                    catch
                     (DocumentClientException de)
                    {

                        Exception baseException = de.GetBaseException();

                        Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);

                    }

                  

                }
            }
            catch (DocumentClientException de)
            {

                Exception baseException = de.GetBaseException();

                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);

            }

           // return false;
        }
    }
}
