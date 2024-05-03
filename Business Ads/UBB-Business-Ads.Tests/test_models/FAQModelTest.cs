// <copyright file="FAQModelTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UBB_Business_Ads.Tests.Test_models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using NUnit;
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

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
        public void EmptyConstructor_InitializesProperties()
        {
            FAQ faq;

            faq = new FAQ();

            // Assert.That(faq.Id, Is.EqualTo(1));
            Assert.That(faq.Question, Is.EqualTo(string.Empty));
            Assert.That(faq.Answer, Is.EqualTo(string.Empty));
            Assert.That(faq.Topic, Is.EqualTo(string.Empty));
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
