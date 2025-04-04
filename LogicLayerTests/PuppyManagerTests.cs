using DataAccessFakes;
using DataDomain;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    [TestClass]
    public class PuppyManagerTests
    {
        private IPuppyManager? _puppyManager;


        [TestInitialize]
        public void TestSetup()
        {
            _puppyManager = new PuppyManager(new PuppyAccessorFake()); 

        }

        [TestMethod]
        public void TestRetrievePuppiesByLitterIDReturnsCorrectBreed()
        {

            // arrange 
            const string expectedBreed = "Aussiedoodle";
            const string litterID = "AussieLit1";

            // act
            List<Puppy> puppies = _puppyManager.SelectPuppiesByLitterID(litterID);

            // assert
            foreach (var puppy in puppies)
            {
                Assert.AreEqual(expectedBreed, puppy.BreedID);
            }
        }

        [TestMethod]
        public void TestUpdatePuppyReturns1ForSuccess()
        {
            //arrange
            const string puppyID = "ALit1One";
            const bool oldAdopted = false;
            const bool newAdopted = true;
            int expectedResult = 1;
            int actualResult = 0;

            //act
            actualResult = _puppyManager.UpdatePuppy(puppyID, oldAdopted, newAdopted);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetrievePuppiesReturnsCorrectNumber()
        {

            // Arrange
            const int expectedNumber = 2;

            // Act
            List<Puppy> puppies = _puppyManager.GetAllPuppies();
            int actualNumber = puppies.Count;

            // Assert
            Assert.AreEqual(expectedNumber, actualNumber);
        }

    }
}