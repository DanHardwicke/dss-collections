using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCS.DSS.Collections.Models;
using NCS.DSS.Collections.Validators;
using System;
using System.Linq;

namespace NCC.DSS.Collections.Tests.Validators
{
    [TestClass]
    public class CollectionValidatorTests
    {
        [TestMethod]        
        public void Validate_Collection_Test_Positive()
        {
            //Assign
            var collection = new Collection();
            var collectionValidator = new CollectionValidator();

            //Act            
            Guid collectionId = Guid.NewGuid();
            Guid touchpointId = Guid.NewGuid();
            DateTime lastUpdated = DateTime.Now;
            string ukprn = "12345678";

            collection.CollectionId = collectionId;
            collection.LastModifiedDate = lastUpdated;
            collection.TouchPointId = touchpointId;
            collection.UKPRN = ukprn;

            var result = collectionValidator.Validate(collection).Result;

            //Assert
            Assert.AreEqual(false, result.Any());
            Assert.IsNotNull(collection);
            Assert.AreEqual(collectionId, collection.CollectionId);
            Assert.AreEqual(touchpointId, collection.TouchPointId);
            Assert.AreEqual(lastUpdated, collection.LastModifiedDate);
            Assert.AreEqual(ukprn, collection.UKPRN);
        }

        [TestMethod]
        public void Validate_Collection_Test_Null_Collection_Id()
        {
            //Assign
            var collection = new Collection();
            var collectionValidator = new CollectionValidator();

            //Act            
            Guid touchpointId = Guid.NewGuid();
            DateTime lastUpdated = DateTime.Now;
            string ukprn = "12345678";
            
            collection.LastModifiedDate = lastUpdated;
            collection.TouchPointId = touchpointId;
            collection.UKPRN = ukprn;            

            var result = collectionValidator.Validate(collection).Result;

            //Assert
            Assert.AreEqual(0, result.Count());
            Assert.IsNotNull(collection);
            Assert.IsNotNull(collection.CollectionId);
            Assert.AreEqual(touchpointId, collection.TouchPointId);
            Assert.AreEqual(lastUpdated, collection.LastModifiedDate);
            Assert.AreEqual(ukprn, collection.UKPRN);
        }

        [TestMethod]
        public void Validate_Collection_Test_Null_TouhPoint_Id()
        {
            //Assign
            var collection = new Collection();
            var collectionValidator = new CollectionValidator();

            //Act            
            Guid collectionId = Guid.NewGuid();
            DateTime lastUpdated = DateTime.Now;
            string ukprn = "12345678";

            collection.CollectionId = collectionId;
            collection.LastModifiedDate = lastUpdated;            
            collection.UKPRN = ukprn;

            var result = collectionValidator.Validate(collection).Result;

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsNotNull(collection);
            Assert.AreEqual(collectionId, collection.CollectionId);
            Assert.AreEqual(Guid.Empty, collection.TouchPointId);
            Assert.AreEqual(lastUpdated, collection.LastModifiedDate);
            Assert.AreEqual(ukprn, collection.UKPRN);
        }

        [TestMethod]
        public void Validate_Collection_Test_Null_Last_Modified_Date()
        {
            //Assign
            var collection = new Collection();
            var collectionValidator = new CollectionValidator();

            //Act            
            Guid collectionId = Guid.NewGuid();
            Guid touchpointId = Guid.NewGuid();            
            string ukprn = "12345678";

            collection.CollectionId = collectionId;
            collection.TouchPointId = touchpointId;            
            collection.UKPRN = ukprn;

            var result = collectionValidator.Validate(collection).Result;

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsNotNull(collection);
            Assert.AreEqual(collectionId, collection.CollectionId);
            Assert.AreEqual(touchpointId, collection.TouchPointId);
            Assert.AreEqual(null, collection.LastModifiedDate);
            Assert.AreEqual(ukprn, collection.UKPRN);
        }

        [TestMethod]
        public void Validate_Collection_Test_UKPRN_Too_Long()
        {
            //Assign
            var collection = new Collection();
            var collectionValidator = new CollectionValidator();

            //Act            
            Guid collectionId = Guid.NewGuid();
            Guid touchpointId = Guid.NewGuid();
            DateTime lastUpdated = DateTime.Now;
            string ukprn = "123456789";

            collection.CollectionId = collectionId;
            collection.TouchPointId = touchpointId;
            collection.LastModifiedDate = lastUpdated;
            collection.UKPRN = ukprn;

            var result = collectionValidator.Validate(collection).Result;

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsNotNull(collection);
            Assert.AreEqual(collectionId, collection.CollectionId);
            Assert.AreEqual(touchpointId, collection.TouchPointId);
            Assert.AreEqual(lastUpdated, collection.LastModifiedDate);
            Assert.AreEqual(ukprn, collection.UKPRN);
        }

        [TestMethod]
        public void Validate_Collection_Test_UKPRN_Too_Short()
        {
            //Assign
            var collection = new Collection();
            var collectionValidator = new CollectionValidator();

            //Act            
            Guid collectionId = Guid.NewGuid();
            Guid touchpointId = Guid.NewGuid();
            DateTime lastUpdated = DateTime.Now;
            string ukprn = "1234567";

            collection.CollectionId = collectionId;
            collection.TouchPointId = touchpointId;
            collection.LastModifiedDate = lastUpdated;
            collection.UKPRN = ukprn;

            var result = collectionValidator.Validate(collection).Result;

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsNotNull(collection);
            Assert.AreEqual(collectionId, collection.CollectionId);
            Assert.AreEqual(touchpointId, collection.TouchPointId);
            Assert.AreEqual(lastUpdated, collection.LastModifiedDate);
            Assert.AreEqual(ukprn, collection.UKPRN);
        }
    }
}
