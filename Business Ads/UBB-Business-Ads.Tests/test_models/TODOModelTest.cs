﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework.Legacy;
using NUnit.Framework;
using NUnit;
using Backend.Models;


namespace UBB_Business_Ads.Tests.test_models
{
    [TestFixture]
    public class TODOModelTest
    {
        [Test]
        public void TODOModel_GettingAndSettingProperties_SuccessGettingAndSettingPropertiesForTODO()
        {
            // Arrange
            TODOClass todoElement = new TODOClass();
            TODOClass parameterdTODO = new TODOClass("testParameteredTask");

            
            // Act
            todoElement.ID = 1;
            todoElement.Task = "testTask";
            parameterdTODO.ID = 2;


            // Assert
            Assert.That(todoElement.ID, Is.EqualTo(1));
            Assert.That(todoElement.Task, Is.EqualTo("testTask"));
            Assert.That(parameterdTODO.ID, Is.EqualTo(2));
            Assert.That(parameterdTODO.Task, Is.EqualTo("testParameteredTask"));
        }

        [Test]
        public void TODOModel_TODOToString_ReturnsExpectedStringFormat()
        {
            // Arrange
            TODOClass todoElement = new TODOClass("testTask");


            // Act
            todoElement.ID = 999;


            // Assert
            Assert.That(todoElement.ToString(), Is.EqualTo("999. testTask"));
        }
    }
}