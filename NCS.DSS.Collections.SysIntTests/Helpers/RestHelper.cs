using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;


namespace NCS.DSS.Collections.SysIntTests.Helpers
{
    public class RestHelper
    {
        static int SecondsToday;
        static int RequestThisSecond = 0;
        static int MaxPerSecond = 1;

        public RestHelper()
        {
            SecondsToday = GetSecondsToday();
        }

        public static void WaitForThrottle()
        {
            while( SecondsToday == GetSecondsToday() && RequestThisSecond >= MaxPerSecond)
            {
                Console.WriteLine("Waiting for throttle: " + RequestThisSecond + " " + GetSecondsToday() + " " + RequestThisSecond);
                Thread.Sleep(250);
            }
            RequestThisSecond = (SecondsToday == GetSecondsToday() ? RequestThisSecond + 1 : 0);
            SecondsToday = GetSecondsToday();

        }




        private static int GetSecondsToday()
        {
            return (int)(DateTime.Now - DateTime.Today).TotalSeconds;
        }
        public RestClient endpoint = null;

        public RestClient SetEndpoint(string endpointUrl)
        {
            endpoint = new RestClient(endpointUrl);
            return endpoint;
        }


        internal static IRestResponse Post(string url, string json, string touchPointId, string subscriptionKey)
        {
            Console.WriteLine("Attempt to POST: " + url);
            Console.WriteLine("Header value: touchPointId: " + touchPointId);
            Console.WriteLine("JSON Document: " + json);
            try
            {

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("TouchpointId", touchPointId);
                request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
                request.AddParameter("undefined", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception e) { throw e; }
        }


        internal static IRestResponse Patch(string url, string json, string touchPointId, string subscriptionKey, string id)
        {
            Console.WriteLine("Attempt to PATCH: " + url);
            try
            {
                var client = new RestClient(url + id);
                var request = new RestRequest(Method.PATCH);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("TouchpointId", touchPointId);
                request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
                request.AddParameter("undefined", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception e) { throw e; }
        }

        internal static IRestResponse Get(string url, string touchPointId, string subscriptionKey)
        {
            Console.WriteLine("Attempt to GET: " + url);
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("TouchpointId", touchPointId);
                request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception e) { throw e; }
        }

        internal static IRestResponse GetSearch(string url, string touchPointId, string subscriptionKey)
        {
            Console.WriteLine("Attempt to GET: " + url);
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("TouchpointId", touchPointId);
                request.AddHeader("api-key", subscriptionKey);
                WaitForThrottle();
                IRestResponse response = client.Execute(request);
                return response;
            }
            catch (Exception e) { throw e; }
        }



        /*public static Task<IRestResponse> ExecuteTaskAsync(this RestClient @this, RestRequest request)
        {
            if (@this == null)
                throw new NullReferenceException();

            var tcs = new TaskCompletionSource<IRestResponse>();

            @this.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                    tcs.TrySetException(response.ErrorException);
                else
                    tcs.TrySetResult(response);
            });

            return tcs.Task;
        }*/

        //internal static async Task<IRestResponse> GetAsync(string url)
        //{
        //    var client = new RestClient(url);
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("cache-control", "no-cache");
        //    request.AddHeader("TouchpointId", testTouchpointId);
        //    request.AddHeader("Ocp-Apim-Subscription-Key", testSubscriptionKey);
        //    IRestResponse response = await client.ExecuteTaskAsync(request);
        //    return response;
        //}

    }





}
