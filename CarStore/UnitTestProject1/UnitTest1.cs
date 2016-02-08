//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using CarStore.Controllers;

//namespace UnitTestProject1
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//            //Arrange
//            HomeController home = new HomeController();

//            //Act
//            var result = home.About();

//            //Assert
//            Assert.IsNotNull(result);
//        }
//    }

//    [TestClass]
//    public class UnitTest2
//    {
//        [TestMethod]
//        public void CarTest()
//        {
//            //Arrange
//            CarsController cars = new CarsController();

//            //Act
//            var result = cars.Create(new CarStore.Models.CarViewModel
//            {
//                Make = "Lel",
//                Model = "Test",
//                Available = true
//            });

//            //Assert
//            Assert.IsNotNull(result);
//        }
//    }
//}
