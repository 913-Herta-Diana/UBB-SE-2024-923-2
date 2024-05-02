namespace Backend.Services
{
    using Backend.Models;
    using Backend.Repositories;

    public class ReviewService : IServiceReview
    {
        private static readonly ReviewService TheInstance = new ReviewService();
        private ReviewRepository repo;

        private ReviewService()
        {
            repo = new ReviewRepository();
        }

        public static ReviewService Instance
        {
            get { return TheInstance; }
        }

        public List<ReviewClass> GetAllReviews()
        {
            return repo.GetReviewList();
        }

        public void AddReview(string review)
        {
            string user = "Dan Oliver";
            ReviewClass addingRev = new ReviewClass(user, review);
            repo.addReview(addingRev);
        }
    }

    public interface IServiceReview
    {
        List<ReviewClass> GetAllReviews();

        void AddReview(string review);
    }
}
