using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymFitnessClassWebService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRepository;
using GymModels;

namespace GymFitnessClassWebService.Controllers.Tests
{
    [TestClass()]
    public class FitnessStudiosControllerTests
    {
        IGymRepo repo = new MockDB();

        [TestMethod()]
        public void GetFitnessStudioTest()
        {
            // Arrange
            FitnessStudiosController test = new FitnessStudiosController(repo);
            // Act
            var result = test.GetFitnessStudio();
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFitnessStudiobyIdTest()
        {
            // Arrange
            FitnessStudiosController test = new FitnessStudiosController(repo);
            // Act
            var result = test.GetFitnessStudiobyId(2);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetStudiobyNameTest()
        {
            // Arrange
            FitnessStudiosController test = new FitnessStudiosController(repo);
            // Act
            var result = test.GetStudiobyName("Main Studio");
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PostFitnessStudioTest()
        {
            // Arrange
            FitnessStudiosController test = new FitnessStudiosController(repo);
            FitnessStudio newStudio = new FitnessStudio { StudioId = 3, StudioName = "RPM Studio" };
            // Act
            var result = test.PostFitnessStudio(newStudio);
            // Assert
            Assert.IsNotNull(result);
        }
    }
}