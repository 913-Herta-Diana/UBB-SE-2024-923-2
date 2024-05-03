// <copyright file="TODOModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace UBB_Business_Ads.Tests.Test_models
{
    using Backend.Models;
    using NUnit.Framework;

    [TestFixture]
    public class TODOModelTest
    {
        [Test]
        public void TODOModel_GettingAndSettingProperties_SuccessGettingAndSettingPropertiesForTODO()
        {
            // Arrange
            var todoElement = new TODOClass();
            var parameterdTODO = new TODOClass("testParameteredTask");

            // Act
            todoElement.ID = 1;
            todoElement.Task = "testTask";
            parameterdTODO.ID = 2;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(todoElement, Has.Property(nameof(TODOClass.ID)).EqualTo(1)
                                          .And.Property(nameof(TODOClass.Task)).EqualTo("testTask"));

                Assert.That(parameterdTODO, Has.Property(nameof(TODOClass.ID)).EqualTo(2)
                                             .And.Property(nameof(TODOClass.Task)).EqualTo("testParameteredTask"));
            });
        }

        [Test]
        public void TODOModel_TODOToString_ReturnsExpectedStringFormat()
        {
            // Arrange
            var todoElement = new TODOClass("testTask")
            {
                ID = 999,
            };

            // Assert
            Assert.That(todoElement.ToString(), Is.EqualTo("999. testTask"));
        }
    }
}