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
        public void FAQConstructors_SettingPropertiesCorrectly_SuccessSettingPropertiesForFAQ()
        {
            string question = "What is that?";
            string answer = "this";
            string topic = "General";

            FAQ faq = new FAQ(question, answer, topic);

            Assert.Multiple(() =>
            {
                Assert.That(faq, Has.Property(nameof(FAQ.Question)).EqualTo("What is that?")
                                          .And.Property(nameof(FAQ.Answer)).EqualTo("this").And.Property(nameof(FAQ.Topic)).EqualTo("General"));
            });
        }

        [Test]
        public void EmptyConstructor_InitializesProperties_SuccessInitialisingEmptyProperties()
        {
            FAQ faq;

            faq = new FAQ();

            Assert.Multiple(() =>
            {
                Assert.That(faq, Has.Property(nameof(FAQ.Question)).EqualTo(string.Empty)
                                          .And.Property(nameof(FAQ.Answer)).EqualTo(string.Empty).And.Property(nameof(FAQ.Topic)).EqualTo(string.Empty));
            });
        }

        [Test]
        public void FAQToString_GettingTheStringRepresentationOfFAQ_ShouldReturnQuestion()
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
