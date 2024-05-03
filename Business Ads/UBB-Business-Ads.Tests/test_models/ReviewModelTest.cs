// <copyright file="ReviewModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.Test_models
{
    using Backend.Models;
    using NUnit.Framework;

    [TestFixture]
    public class ReviewModelTest
    {
        [Test]
        public void ReviewModel_GettingAndSettingProperties_SuccessGettingAndSettingPropertiesForReview()
        {
            // Arrange
            var reviewTest = new ReviewClass();
            var parameterizedReviewTest = new ReviewClass("testUser", "testReview");

            // Act
            reviewTest.User = "testUser";
            reviewTest.Review = "testReview";

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(reviewTest, Has.Property(nameof(ReviewClass.User)).EqualTo("testUser")
                                          .And.Property(nameof(ReviewClass.Review)).EqualTo("testReview"));

                Assert.That(parameterizedReviewTest, Has.Property(nameof(ReviewClass.User)).EqualTo("testUser")
                                                     .And.Property(nameof(ReviewClass.Review)).EqualTo("testReview"));
            });
        }

        [Test]
        public void ReviewModel_ReviewToString_ReturnsExpectedString()
        {
            // Arrange
            var reviewTest = new ReviewClass
            {
                User = "testUser",
                Review = "testReview",
            };

            // Assert
            Assert.That(reviewTest.ToString(), Is.EqualTo("--> testReview (left from testUser)\n"));
        }
    }
}