// <copyright file="FAQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using System.Reflection.Metadata.Ecma335;
    using Backend.Models;
    using Backend.Repositories;

    public class FAQService : IFAQService
    {
        private static readonly FAQService InstanceValue = new ();
        private readonly List<string> topics = new List<string>();
        private readonly FAQRepository repository;
        private readonly List<FAQ> submittedQuestions;

        public FAQService()
        {
            this.repository = new FAQRepository();
            this.submittedQuestions = new List<FAQ>();
        }

        public static FAQService Instance
        {
            get { return InstanceValue; }
        }

        public List<FAQ> GetAllFAQs()
        {
            return this.repository.GetFAQList();
        }

        public List<string> GetTopics()
        {
            List<Backend.Models.FAQ> faqs = this.GetAllFAQs();
            foreach (Backend.Models.FAQ faq in faqs)
            {
                if (!this.topics.Contains(faq.Topic))
                {
                    this.topics.Add(faq.Topic);
                }
            }

            return this.topics;
        }

        public void AddSubmittedQuestion(FAQ newQ)
        {
            this.submittedQuestions.Add(newQ);
        }

        public List<FAQ> GetSubmittedQuestions()
        {
            return this.submittedQuestions;
        }

        public List<FAQ> FilterFAQs(List<FAQ> faqs, string searchText)
        {
            searchText = searchText.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                return faqs
                    .Where(faq =>
                        faq.Question.ToLower().Contains(searchText) ||
                        faq.Topic.ToLower() == searchText)
                    .ToList();
            }

            return faqs;
        }
    }
}
