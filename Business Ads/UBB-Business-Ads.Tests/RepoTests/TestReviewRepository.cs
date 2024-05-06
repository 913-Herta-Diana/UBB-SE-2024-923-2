namespace UBB_Business_Ads.Tests.RepoTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using Backend.Repositories;
    using Xunit;

    public class TestReviewRepository: IDisposable
    {
        private ReviewRepository repository;

        public void Dispose()
        {
        }

        public TestReviewRepository()
        {
            this.repository = new ReviewRepository();
        }

        [Fact]
        public void AddReview_WhenReviewElementIsAdded_ShouldAddElement()
        {
            var reviewElement = new ReviewClass("user1", "review1");
            this.repository.AddReview(reviewElement);
            Xunit.Assert.Contains(reviewElement, this.repository.GetReviewList());
        }

        [Fact]
        public void GetReviewList_WhenFetchingReviews_ShouldReturnReviewsListSameNumberOfElements()
        {
            var result = this.repository.GetReviewList();
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(expected: this.repository.GetReviewList().Count, result.Count());
        }
    }
}