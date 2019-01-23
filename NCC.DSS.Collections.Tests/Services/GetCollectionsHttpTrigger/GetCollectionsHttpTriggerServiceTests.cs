using DFC.HTTP.Standard;
using NCC.DSS.Collections.Tests.Helpers;
using NCS.DSS.Collections.Cosmos.Provider;
using NCS.DSS.Collections.GetCollectionsHttpTrigger.Service;
using NCS.DSS.Collections.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace NCC.DSS.Collections.Tests.Services.GetCollectionsHttpTrigger
{
    [TestFixture]
    public class GetCollectionsHttpTriggerServiceTests
    {
        private IHttpRequestHelper _requestHelper;
        private IDocumentDBProvider _documentDBProvider;
        private Collection _collection;
        private List<Collection> _collections;
        private Guid _touchPointId;
        private Guid _collectionId;        

        private void Setup()
        {
            _requestHelper = Substitute.For<IHttpRequestHelper>();
            _documentDBProvider = MockingHelper.GetMockDBProvider();
            _collection = Substitute.For<Collection>();
            _collections = Substitute.For<List<Collection>>();
            _touchPointId = Guid.NewGuid();
            _collectionId = Guid.NewGuid();
        }


        [Test]
        public void GetCollectionsHttpTriggerService_Create_Test()
        {     
            //Act
            IGetCollectionsHttpTriggerService service = new GetCollectionsHttpTriggerService(new DocumentDBProvider());

            //Assert
            Assert.IsNotNull(service);
        }

        [Test]
        public void GetCollectionsHttpTriggerService_Process_Test()
        {
            //Assign                           
            Setup();
            _documentDBProvider.DoesCollectionResourceExist(_collection).Returns<bool>(true);            
            _documentDBProvider.GetCollectionsForTouchpointAsync(_touchPointId).Returns(Task.FromResult(Task.FromResult(_collections).Result));

            IGetCollectionsHttpTriggerService service = new GetCollectionsHttpTriggerService(_documentDBProvider);

            //Act
            IEnumerable<Collection> result = service.ProcessRequestAsync(_touchPointId).Result;

            //Assert
            Assert.IsNotNull(service);
            Assert.IsNotNull(result);            
        }
    }
}
