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
    public class ReviewModelTest
    {
        [Test]
        public void ReviewModel_GettingAndSettingProperties_SuccessGettingAndSettingPropertiesForReview()
        {
            // Arrange
            ReviewClass reviewTest = new ReviewClass();
            ReviewClass parameterizedReviewTest = new ReviewClass("testUser", "testReview");


            // Act
            reviewTest.User = "testUser";
            reviewTest.Review = "testReview";


            // Assert
            Assert.That(reviewTest.User, Is.EqualTo("testUser"));
            Assert.That(reviewTest.Review, Is.EqualTo("testReview"));
            Assert.That(parameterizedReviewTest.User, Is.EqualTo("testUser"));
            Assert.That(parameterizedReviewTest.Review, Is.EqualTo("testReview"));
        }

        [Test]
        public void ReviewModel_ReviewToString_ReturnsExpectedString()
        {
            // Arrange
            ReviewClass reviewTest = new ReviewClass();


            // Act
            reviewTest.User = "testUser";
            reviewTest.Review = "testReview";


            // Assert
            Assert.That(reviewTest.ToString(), Is.EqualTo("--> testReview (left from testUser)\n"));
        }
    }
}