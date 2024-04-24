using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class FAQService:IFAQService
    {
        private static readonly FAQService instance = new();
        private FAQRepository repository;
        private List<FAQ> submittedQuestions;

        private FAQService()
        {
            repository = new FAQRepository();
            submittedQuestions = new List<FAQ>();
        }

        public static FAQService Instance
        {
            get { return instance; }
        }

        public List<FAQ> GetAllFAQs()
        {
            return repository.GetFAQList();
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
