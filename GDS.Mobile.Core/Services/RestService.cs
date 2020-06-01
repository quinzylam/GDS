using GDS.Core.Logging;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace GDS.Mobile.Core.Services
{
    public class RestService : IRestService
    {
        private bool initialRequest;
        private readonly ILogger _logger;

        public RestService(ILogger logger)
        {
            _logger = logger;
            InitRestClient();
        }

        public IODataClient Client { get; private set; }

        private void InitRestClient()
        {
            Client = new ODataClient(new ODataClientSettings(new Uri(Constants.API_URL))
            {
                IgnoreUnmappedProperties = true,
                BeforeRequest = GetRequest,
                AfterResponse = GetResponse,
                PayloadFormat = ODataPayloadFormat.Json,
                PreferredUpdateMethod = ODataUpdateMethod.Put,
            });
        }

        internal HttpRequestMessage Request { get; private set; }
        internal HttpResponseMessage Response { get; private set; }
        public bool IsOnline { get; private set; }
        public Exception Exception { get; private set; }

        private void GetResponse(HttpResponseMessage responseMessage)
        {
            Response = responseMessage;
            if (!responseMessage.IsSuccessStatusCode)
            {
                switch (Response.StatusCode)
                {
                    case HttpStatusCode.ServiceUnavailable:
                        IsOnline = false;
                        break;

                    default:
                        Exception = HandleResponseError(Response);
                        break;
                }
            }
            else
            {
                if (initialRequest)
                    IsOnline = initialRequest;
                initialRequest = false;
            }
        }

        private Exception HandleResponseError(HttpResponseMessage response)
        {
            var ex = new Exception(response.ReasonPhrase);
            _logger.Error($"Non success response [Code: {response.StatusCode}] encountered while performing {response.RequestMessage.Method} request to REST API for resource {response.RequestMessage.RequestUri}.{Environment.NewLine}", ex);
            return ex;
        }

        private void GetRequest(HttpRequestMessage requestMessage)
        {
            Request = requestMessage;
            var baseUrl = string.Concat(Constants.API_URL, "$metadata");
            if (requestMessage.RequestUri.OriginalString == baseUrl)
                initialRequest = true;
        }
    }
}