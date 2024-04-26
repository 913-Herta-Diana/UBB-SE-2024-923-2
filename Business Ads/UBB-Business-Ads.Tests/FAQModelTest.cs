using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using NUnit;
using Backend.Models;

namespace UBB_Business_Ads.Tests
{
    [TestFixture]
    internal class FAQModelTest
    {
        [Test]
        public void FAQ_Constructors_ShouldSetPropertiesCorrectly()
        {
            string question = "What is that?";
            string answer = "this";
            string topic = "General";

            FAQ faq = new FAQ(question, answer, topic);

            Assert.That(faq.Question, Is.EqualTo(question));
            Assert.That(faq.Answer, Is.EqualTo(answer));
            Assert.That(faq.Topic, Is.EqualTo(topic));
        }

        [Test]
        public void FAQ_ToString_ShouldReturnQuestion()
        {
            string question = "What is that?";
            string answer = "this";
            string topic = "General";
            FAQ faq = new FAQ(question, answer, topic);

            string result = faq.ToString();
            Assert.That(question, Is.EqualTo(result));
        }
    }
}
