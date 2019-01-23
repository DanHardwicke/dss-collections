using DFC.Common.Standard.Logging;
using DFC.HTTP.Standard;
using DFC.JSON.Standard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using NCS.DSS.Collections.Cosmos.Helper;
using NCS.DSS.Collections.Models;
using NCS.DSS.Collections.PostCollectionHttpTrigger.Service;
using NCS.DSS.Collections.Validators;
using Newtonsoft.Json;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace NCC.DSS.Collections.Tests.Services.PostCollectionHttpTrigger
{

    [TestFixture]    
    public class PostCollectionHttpTriggerServiceTests
    {
        private const string ValidCustomerId = "7E467BDB-213F-407A-B86A-1954053D3C24";
        private const string ValidInteractionId = "1e1a555c-9633-4e12-ab28-09ed60d51cb3";
        private const string ValidDssCorrelationId = "452d8e8c-2516-4a6b-9fc1-c85e578ac066";
        private const string InValidId = "1111111-2222-3333-4444-555555555555";

        private ILogger _log;
        private HttpRequest _request;
        private IResourceHelper _resourceHelper;        
        private IPostCollectionHttpTriggerService _postCollectionHttpTriggerService;
        private ILoggerHelper _loggerHelper;
        private IHttpRequestHelper _httpRequestHelper;
        private IHttpResponseMessageHelper _httpResponseMessageHelper;
        private IJsonHelper _jsonHelper;
        private Collection _collection;
        private IDssCorrelationValidator _dssCorrelationValidator;
        private IDssTouchpointValidator _dssTouchpointValidator;        

        [SetUp]
        public void Setup()
        {
            _collection = Substitute.For<Collection>();
            _request = new DefaultHttpRequest(new DefaultHttpContext());
            _resourceHelper = Substitute.For<IResourceHelper>();
            _loggerHelper = Substitute.For<ILoggerHelper>();
            _httpRequestHelper = Substitute.For<IHttpRequestHelper>();
            _httpResponseMessageHelper = Substitute.For<IHttpResponseMessageHelper>();
            _jsonHelper = Substitute.For<IJsonHelper>();
            _log = Substitute.For<ILogger>(); _resourceHelper = Substitute.For<IResourceHelper>();
            _postCollectionHttpTriggerService = Substitute.For<IPostCollectionHttpTriggerService>();

            _dssCorrelationValidator = new DssCorrelationValidator(_httpRequestHelper);
            _dssTouchpointValidator = new DssTouchpointValidator(_httpRequestHelper, _loggerHelper, _dssCorrelationValidator);

            _httpRequestHelper.GetDssCorrelationId(_request).Returns(ValidDssCorrelationId);
            _httpRequestHelper.GetDssTouchpointId(_request).Returns("0000000001");
            _httpRequestHelper.GetDssApimUrl(_request).Returns("http://localhost:");            
        }

        [Test]
        public async Task PostCollectionHttpTrigger_ReturnsStatusCodeBadRequest_WhenTouchpointIdIsNotProvided()
        {
            //Assign
            _httpRequestHelper.GetResourceFromRequest<Collection>(_request).Returns(Task.FromResult(_collection).Result);
            _httpRequestHelper.GetDssTouchpointId(_request).Returns((string)null);

            _httpResponseMessageHelper.BadRequest().Returns(x => new HttpResponseMessage(HttpStatusCode.BadRequest));

            // Act
            var result = await RunFunction();

            // Assert
            Assert.IsInstanceOf<HttpResponseMessage>(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public async Task PostCollectionHttpTrigger_ReturnsStatusCodeBadRequest_WhenCorrelationIdIsNotProvided()
        {
            //Assign
            _httpRequestHelper.GetDssCorrelationId(_request).Returns((string)null);

            _httpResponseMessageHelper.BadRequest().Returns(x => new HttpResponseMessage(HttpStatusCode.BadRequest));

            // Act
            var result = await RunFunction();

            // Assert
            Assert.IsInstanceOf<HttpResponseMessage>(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public async Task PostCollectionHttpTrigger_ReturnsStatusCodeBadRequest_WhenApimUrlIsNotProvided()
        {
            //Assign
            _httpRequestHelper.GetDssApimUrl(_request).Returns((string)null);

            _httpResponseMessageHelper.BadRequest().Returns(x => new HttpResponseMessage(HttpStatusCode.BadRequest));

            // Act
            var result = await RunFunction();

            // Assert
            Assert.IsInstanceOf<HttpResponseMessage>(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public async Task PostCollectionHttpTrigger_ReturnsStatusCodeUnprocessableEntity_WhenACollectionRequestIsInvalid()
        {
            //Assign
            _httpRequestHelper.GetResourceFromRequest<Collection>(_request).Throws(new JsonException());

            _httpResponseMessageHelper
                .UnprocessableEntity(Arg.Any<JsonException>()).Returns(x => new HttpResponseMessage((HttpStatusCode)422));

            //Act
            var result = await RunFunction();

            // Assert
            Assert.IsInstanceOf<HttpResponseMessage>(result);
            Assert.AreEqual((HttpStatusCode)422, result.StatusCode);
        }

        [Test]
        public async Task PostCollectionHttpTrigger_ReturnsStatusCodeCreated_WhenRequestIsValid()
        {
            //Assign
            _httpRequestHelper.GetResourceFromRequest<Collection>(_request).Returns(Task.FromResult(_collection).Result);
            
            _postCollectionHttpTriggerService.ProcessRequestAsync(Arg.Any<Collection>()).Returns(Task.FromResult(_collection).Result);

            _httpResponseMessageHelper
                .Created(Arg.Any<string>()).Returns(x => new HttpResponseMessage(HttpStatusCode.Created));

            //Act
            var result = await RunFunction();

            // Assert
            Assert.IsInstanceOf<HttpResponseMessage>(result);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

        private async Task<HttpResponseMessage> RunFunction()
        {
            return await NCS.DSS.Collections.PostCollectionHttpTrigger.Function.PostCollectionHttpTrigger.RunAsync(
                _request,
                _log,
                _postCollectionHttpTriggerService,
                _httpRequestHelper,
                _httpResponseMessageHelper,
                _jsonHelper,                
                _dssCorrelationValidator,
                _dssTouchpointValidator).ConfigureAwait(false);
        }
    }
}
