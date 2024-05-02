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
        private ReviewRepository _reviewRepository;

        [SetUp]
        public void Setup()
        {
            _reviewRepository = new ReviewRepository();
        }
        [Test]
        public void Test_GetReviewS()
        {
            var result = _reviewRepository.GetReviewList();
            var expectedReviewListCount = _reviewRepository.GetReviewList().Count;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(expectedReviewListCount));
        }
        [Test]
        public void Test_AddReviewS()
        {
            int initialReviewsCount = _reviewRepository.GetReviewList().Count;
            var newReviewToAdd = new ReviewClass("user1", "review1");
            _reviewRepository.AddReview(newReviewToAdd);
            var todosList = _reviewRepository.GetReviewList();
            var updatedTodosCount = todosList.Count;

            Assert.Multiple(() =>
            {
                Assert.That(updatedTodosCount, Is.EqualTo(initialReviewsCount + 1));
                Assert.That(todosList, Does.Contain(newReviewToAdd));
            });

        }

    }
}
