using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    internal interface INterfaceReview
    {
        public List<ReviewClass> GetReviewList();

        public void AddReview(ReviewClass newR);
    }
}
