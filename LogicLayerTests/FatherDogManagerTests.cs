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
    public class FatherDogManagerTests
    {
        private IFatherDogManager? _fatherDogManager;


        [TestInitialize]
        public void TestSetup()
        {
            _fatherDogManager = new FatherDogManager(new FatherDogAccessorFake()); 

        }

        [TestMethod]
        public void TestSelectFatherDogByFatherDogIDReturnsCorrectFatherDog()
        {


            // arrange 
            const string expectedImage = "cockapoo.jpg";
            const string fatherDogID = "Fonzi";
            string actualImage = "cockapoo.jpg";

            // act
            actualImage = _fatherDogManager.SelectFatherDogByFatherDogID(fatherDogID).Image;

            // assert
            Assert.AreEqual(expectedImage, actualImage);
        }
    }
}