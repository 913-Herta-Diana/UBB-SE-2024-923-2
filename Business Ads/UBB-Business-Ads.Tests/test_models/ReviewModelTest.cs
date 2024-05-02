<<<<<<< HEAD
﻿namespace UBB_Business_Ads.Tests.Test_models
=======
﻿// <copyright file="ReviewModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.Test_models
>>>>>>> 73c7dcf1d614218690855e9718433ee33c30eab2
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
