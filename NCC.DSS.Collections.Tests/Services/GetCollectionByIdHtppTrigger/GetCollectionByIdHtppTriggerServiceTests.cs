using DFC.HTTP.Standard;
using NCC.DSS.Collections.Tests.Helpers;
using NCS.DSS.Collections.Cosmos.Provider;
using NCS.DSS.Collections.GetCollectionByIdHttpTrigger.Service;
using NCS.DSS.Collections.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace NCC.DSS.Collections.Tests.Services.GetCollectionByIdHtppTrigger
{
    [TestFixture]
    public class GetCollectionByIdHtppTriggerServiceTests
    {
        private IHttpRequestHelper _requestHelper;
        private IDocumentDBProvider _documentDBProvider;
        private Collection _collection;
        private List<Collection> _collections;
        private Guid _touchPointId;
        private Guid _collectionId;

        [SetUp]
        public void Setup()
        {
            _requestHelper = new HttpRequestHelper();
            _documentDBProvider = MockingHelper.GetMockDBProvider();
            _collection = Substitute.For<Collection>();
            _collections = Substitute.For<List<Collection>>();
            _touchPointId = Guid.NewGuid();
            _collectionId = Guid.NewGuid();
        }
        [Test]
        public void GetCollectionByIdHtppTriggerService_Create_Test()
        {                        
            //Act
            IGetCollectionByIdHtppTriggerService service = new GetCollectionByIdHtppTriggerService(_documentDBProvider);            

            //Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void GetCollectionByIdHttpTriggerService_Process_Test()
        {
            //Assign           
            _documentDBProvider.DoesCollectionResourceExist(_collection).Returns<bool>(true);            
            _documentDBProvider.GetCollectionForTouchpointAsync(_touchPointId, _collectionId).Returns(Task.FromResult(_collection).Result);

            //Act
            IGetCollectionByIdHtppTriggerService service = new GetCollectionByIdHtppTriggerService(_documentDBProvider);
            var result = service.ProcessRequestAsync(_touchPointId, _collectionId);

            //Assert
            Assert.IsNotNull(service);
            Assert.IsNotNull(result);
        }        
    }
}
