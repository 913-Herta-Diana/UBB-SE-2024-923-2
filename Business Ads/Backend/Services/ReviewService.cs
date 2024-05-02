using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class ReviewService : IServiceReview
    {
        private static readonly ReviewService instance = new();
        private readonly ReviewRepository repo;

        private ReviewService()
        {
            repo = new ReviewRepository();
        }

        public static ReviewService Instance
        {
            get { return instance; }
        }

        public List<ReviewClass> GetAllReviews()
        {
            return repo.GetReviewList();
        }

        public void AddReview(string review)
        {
            string user = "Dan Oliver";
            ReviewClass addingRev = new(user, review);
            repo.AddReview(addingRev);
        }
    }

    public interface IServiceReview
    {
        List<ReviewClass> GetAllReviews();
        void AddReview(string review);
    }
}
