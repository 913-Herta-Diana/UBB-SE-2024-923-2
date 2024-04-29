// <copyright file="TODOModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.Test_models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

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
