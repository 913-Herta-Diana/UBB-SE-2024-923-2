using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IFAQRepository
    {
        List<FAQ> GetFAQList();
        void addFAQ(FAQ newQ);
        void deleteFAQ(FAQ q);
    }
}
