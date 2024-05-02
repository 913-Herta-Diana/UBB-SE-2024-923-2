namespace UBB_Business_Ads.Tests
{
    using Backend.Services;
    using Moq;
    using Xunit;

    public class ReviewServiceTest
    {
        [Fact]
        public void GetReviewServiceInstanceTest()
        {
            // Act
            ReviewService instance1 = ReviewService.Instance;
            ReviewService instance2 = ReviewService.Instance;

            // Assert
            Xunit.Assert.Equal(instance1, instance2);
        }

        [Fact]
        public void GetAllReviews_Test()
        {
            var reviewService = ReviewService.Instance;

            // Act
            var result = reviewService.GetAllReviews();

            // Assert
            Xunit.Assert.NotNull(result);
        }

        [Fact]
        public void AddReview_Test()
        {
            // Arrange
            var mockService = new Mock<IServiceReview>();

            // Act
            mockService.Object.AddReview("review");

            // Assert
            // Verify that the AddReview method is called on the mock services exactly once
            mockService.Verify(s => s.AddReview("review"), Times.Once);
        }
    }
}
