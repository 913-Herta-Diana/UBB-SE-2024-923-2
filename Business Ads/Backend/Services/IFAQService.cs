using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    internal interface IFAQService
    {
        List<FAQ> GetAllFAQs();
        void AddSubmittedQuestion(FAQ newQuestion);
        List<FAQ> GetSubmittedQuestions();
    }
}
