// <copyright file="ReviewService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using Backend.Models;
    using Backend.Repositories;

    public class ReviewService : IServiceReview
    {
        private static readonly ReviewService TheInstance = new ();
        private readonly ReviewRepository repo;

        private ReviewService()
        {
            this.repo = new ReviewRepository();
        }

        public static ReviewService Instance
        {
            get { return TheInstance; }
        }

        public List<ReviewClass> GetAllReviews()
        {
            return this.repo.GetReviewList();
        }

        public void AddReview(string review)
        {
            string user = "Dan Oliver";
            ReviewClass addingRev = new (user, review);
            this.repo.AddReview(addingRev);
        }
    }

    public interface IServiceReview
    {
        List<ReviewClass> GetAllReviews();

        void AddReview(string review);
    }
}
