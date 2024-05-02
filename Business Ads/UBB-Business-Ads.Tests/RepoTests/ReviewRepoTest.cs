using Backend.Models;
using Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UBB_Business_Ads.Tests.RepoTests
{
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using Moq;

    [TestFixture]
    public class ReviewRepoTests
    {
        private ReviewRepository _reviewRepo;

        [SetUp]
        public void Setup()
        {
            _reviewRepo = new ReviewRepository();
        }
        [Test]
        public void Test_GetReviewS()
        {
            var result = _reviewRepo.GetReviewList();
            var expectedCount = _reviewRepo.GetReviewList().Count();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expectedCount));
        }
        [Test]
        public void Test_AddReviewS()
        {
            int initialReviewsCount = _reviewRepo.GetReviewList().Count();
            var newReview = new ReviewClass("user1", "review1");
            _reviewRepo.addReview(newReview);
            var todosList = _reviewRepo.GetReviewList();
            var updatedTodosCount = todosList.Count;

            Assert.That(updatedTodosCount, Is.EqualTo(initialReviewsCount + 1));
            Assert.That(todosList.Contains(newReview), Is.True);

        }

    }
}
