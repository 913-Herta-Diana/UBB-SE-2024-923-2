using Backend.Models;
using Backend.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace Backend.Services
{
    public class FAQService:IFAQService
    {
        private static readonly FAQService instance = new();
        private readonly List<string> topics = [];
        private readonly FAQRepository repository;
        private readonly List<FAQ> submittedQuestions;

        public FAQService()
        {
            repository = new FAQRepository();
            submittedQuestions = [];
        }

        public static FAQService Instance
        {
            get { return instance; }
        }

        public List<FAQ> GetAllFAQs()
        {
            return repository.GetFAQList();
        }

        public List<string> GetTopics()
        {


            List<Backend.Models.FAQ> faqs = GetAllFAQs();
            foreach (Backend.Models.FAQ faq in faqs)
            {
                if (!topics.Contains(faq.Topic))
                {
                    topics.Add(faq.Topic);
                }
            }
            return topics;
        }

        public void AddSubmittedQuestion(FAQ newQ)
        {
            submittedQuestions.Add(newQ);
        }

        public List<FAQ> GetSubmittedQuestions()
        {
            return submittedQuestions;
        }
    }

}
