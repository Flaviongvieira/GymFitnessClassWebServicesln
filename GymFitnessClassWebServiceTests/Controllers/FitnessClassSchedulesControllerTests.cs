using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymFitnessClassWebService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRepository;
using Microsoft.AspNetCore.Mvc;
using GymModels;

namespace GymFitnessClassWebService.Controllers.Tests
{
    [TestClass()]
    public class FitnessClassSchedulesControllerTests
    {
        IGymRepo repo = new MockDB();

        [TestMethod()]
        public void GetFitnessClassScheduleTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            // Act
            var result = test.GetFitnessClassSchedule();
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFitnessClassbyIdTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            // Act
            var result = test.GetFitnessClassbyId(1);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFitClassScheduleByDayTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            // Act
            var result = test.GetFitClassScheduleByDay(DayOfWeek.Wednesday);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFitClassScheduleByInstrTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            // Act
            var result = test.GetFitClassScheduleByInstr(1);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetFitClassScheduleByStuIdTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            // Act
            var result = test.GetFitClassScheduleByStuId(2);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PutFitnessClassScheduleTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            FitnessClassSchedule classToEdit = new FitnessClassSchedule
            {
                ClassId = 1,
                ClassName = "Pilates Morning",     // => Field Changed from Pilates to Pilates Morning
                ClassWeekDay = DayOfWeek.Wednesday,
                ClassDuration = 45,
                ClassStartTime = "07:45",
                ClassInstrId = 1,
                ClassStudioId = 1
            };

            // Act
            var result = test.PutFitnessClassSchedule(1, classToEdit);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void PostFitnessClassScheduleTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            FitnessClassSchedule newClass = new FitnessClassSchedule
            {
                ClassId = 12,
                ClassName = "RPM Morning",    
                ClassWeekDay = DayOfWeek.Tuesday,
                ClassDuration = 45,
                ClassStartTime = "07:45",
                ClassInstrId = 1,
                ClassStudioId = 1
            };

            // Act
            var result = test.PostFitnessClassSchedule(newClass);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteFitnessClassScheduleTest()
        {
            // Arrange
            FitnessClassSchedulesController test = new FitnessClassSchedulesController(repo);
            // Act
            var result = test.DeleteFitnessClassSchedule(2);
            // Assert
            Assert.IsNotNull(result);
        }
    }
}