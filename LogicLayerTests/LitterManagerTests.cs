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
    public class LitterManagerTests
    {
        private ILitterManager? _litterManager;


        [TestInitialize]
        public void TestSetup()
        {
            _litterManager = new LitterManager(new LitterAccessorFake()); // needs data fakes

        }

        [TestMethod]
        public void TestRetrieveLitterByLitterIDReturnsCorrectLitter()
        {


            // arrange 
            const string expectedImage = "lit5.jpg";
            const string litterID = "AussieLit5";
            string actualImage = "lit5.jpg";

            // act
            actualImage = _litterManager.SelectLitterByLitterID(litterID).Image;

            // assert
            Assert.AreEqual(expectedImage, actualImage);
        }

        [TestMethod]
        public void TestRetrieveLittersReturnsCorrectNumber()
        {

            // Arrange
            const int expectedNumber = 2;

            // Act
            List<Litter> litters = _litterManager.GetAllLitters();
            int actualNumber = litters.Count;

            // Assert
            Assert.AreEqual(expectedNumber, actualNumber);
        }
    }
}