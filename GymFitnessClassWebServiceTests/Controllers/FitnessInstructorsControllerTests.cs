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
    public class FitnessInstructorsControllerTests
    {
        IGymRepo repo = new MockDB();

        [TestMethod()]
        public void GetFitnessInstructorTest()
        {
            // Arrange
            FitnessInstructorsController test = new FitnessInstructorsController(repo);
            // Act
            var result = test.GetFitnessInstructor();
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFitnessInstructorbyIdTest()
        {
            // Arrange
            FitnessInstructorsController test = new FitnessInstructorsController(repo);
            // Act
            var result = test.GetFitnessInstructorbyId(2);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFitnessInstructorbyNameTest()
        {
            // Arrange
            FitnessInstructorsController test = new FitnessInstructorsController(repo);
            // Act
            var result = test.GetFitnessInstructorbyName("Flavio");
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PostFitnessInstructorTest()
        {
            // Arrange
            FitnessInstructorsController test = new FitnessInstructorsController(repo);
            FitnessInstructor newInstr = new FitnessInstructor { InstrId = 1, InstrName = "Nadia", InstrDoB = new DateTime(1990, 7, 11) };
            // Act
            var result = test.PostFitnessInstructor(newInstr);
            // Assert
            Assert.IsNotNull(result);
        }
    }
}