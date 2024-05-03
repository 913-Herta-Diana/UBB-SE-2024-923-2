// <copyright file="ReviewRepoTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.RepoTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Backend.Models;
    using Backend.Repositories;
    using Moq;
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class ReviewRepoTests
    {
        private ReviewRepository reviewRepository;

        [SetUp]
        public void Setup()
        {
            this.reviewRepository = new ReviewRepository();
        }

        [Test]
        public void Test_ConstructorReview()
        {
            Assert.That(this.reviewRepository.GetReviewList(), Is.Not.Null);
        }

        [Test]
        public void Test_GetReviewS()
        {
            var result = this.reviewRepository.GetReviewList();
            var expectedReviewListCount = this.reviewRepository.GetReviewList().Count;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(expectedReviewListCount));
        }

        [Test]
        public void Test_AddReviewS()
        {
            int initialReviewsCount = this.reviewRepository.GetReviewList().Count;
            var newReviewToAdd = new ReviewClass("user1", "review1");
            this.reviewRepository.AddReview(newReviewToAdd);
            var todosList = this.reviewRepository.GetReviewList();
            var updatedTodosCount = todosList.Count;

            Assert.Multiple(() =>
            {
                Assert.That(updatedTodosCount, Is.EqualTo(initialReviewsCount + 1));
                Assert.That(todosList, Does.Contain(newReviewToAdd));
            });
        }
    }
}
