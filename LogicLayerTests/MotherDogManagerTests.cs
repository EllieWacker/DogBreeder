using DataAccessFakes;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    [TestClass]
    public class MotherDogManagerTests
    {
        private IMotherDogManager? _motherDogManager;


        [TestInitialize]
        public void TestSetup()
        {
            _motherDogManager = new MotherDogManager(new MotherDogAccessorFake()); 

        }

        [TestMethod]
        public void TestSelectMotherDogByMotherDogIDReturnsCorrectMotherDog()
        {


            // arrange 
            const string expectedImage = "gracie.jpg";
            const string motherDogID = "Gracie";
            string actualImage = "gracie.jpg";

            // act
            actualImage = _motherDogManager.SelectMotherDogByMotherDogID(motherDogID).Image;

            // assert
            Assert.AreEqual(expectedImage, actualImage);
        }
    }
}