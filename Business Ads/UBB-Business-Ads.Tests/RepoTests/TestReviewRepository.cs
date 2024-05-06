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
            repository.GetReviewList().Clear();
            File.WriteAllText("C:\\Users\\herta\\Desktop\\Sem4\\Biznis\\Business Ads\\UBB-Business-Ads.Tests\\XMLfiles\\REVIEWitems.xml", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Reviews xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <ReviewClass>\r\n    <User>John Doe</User>\r\n    <Review>Great site! I found the information very helpful.</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>Alice Smith</User>\r\n    <Review>Informative content, but the design could be improved.</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>Mike Johnson</User>\r\n    <Review>Helped me understand ad targeting better.</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>Sarah Brown</User>\r\n    <Review>Excellent resource for beginners in digital marketing.</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>David Wilson</User>\r\n    <Review>Could use more detailed explanations on certain topics.</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>Jennifer Lee</User>\r\n    <Review>Love the interactive examples provided.</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>Dan Oliver</User>\r\n    <Review>Liked it.</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>Dan Oliver</User>\r\n    <Review>feedback bun</Review>\r\n  </ReviewClass>\r\n  <ReviewClass>\r\n    <User>user1</User>\r\n    <Review>review1</Review>\r\n  </ReviewClass>\r\n</Reviews>");

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