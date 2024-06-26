﻿// <copyright file="TODOServicesTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.ServicesTests
{
    using Backend.Models;
    using Backend.Services;
    using Moq;
    using Xunit;

    public class TODOServicesTest
    {
        [Fact]
        public void GetTODOServicesInstance_AsssignsValueToOject_ReturnsTheSameInstance()
        {
            // Act = Constructor - testing the constructor
            TODOServices instance1 = TODOServices.Instance;
            TODOServices instance2 = TODOServices.Instance;

            // Assert
            Assert.Equal(instance1, instance2);
        }

        [Fact]
        public void GetTODOS_FetchesToDosFromInstance_ReturnsTheListOfAllTODOS()
        {
            // Constructor
            var todoServices = TODOServices.Instance;

            // Act
            var result = todoServices.GetTODOS();

            // Assert
            Assert.NotNull(result);
        }
        //comment for commiting

        [Fact]
        public void AddTODO_AddingTODOElement_NeedsToCallTheAddFunctionFromRepoAndAddElementToTheList()
        {
            // Constructor
            var mockServices = new Mock<IServicesTODO>();
            var todoObject = new TODOClass();

            // Act
            mockServices.Object.AddTODO(todoObject);

            // Assert
            // Verify that the addTODO method is called on the mock services exactly once
            mockServices.Verify(s => s.AddTODO(todoObject), Times.Once);
        }

        [Fact]
        public void RemoveTODO_DeletingElementWhenNonExistingId_NothingShouldHappen()
        {
            // Constructor
            var todoServices = TODOServices.Instance;
            int nonExistingId = 9999; // Non-existing id
            int size = todoServices.GetTODOS().Count;

            // Act
            todoServices.RemoveTODO(nonExistingId);

            // Assert
            // Verify that no actions are performed
            // The list of TODOs remains same
            Assert.Equal(size, todoServices.GetTODOS().Count);
        }
    }
}
