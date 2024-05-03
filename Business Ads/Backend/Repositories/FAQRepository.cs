// <copyright file="FAQRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System.Xml;
    using System.Xml.Serialization;
    using Backend.Models;

    public class FAQRepository : IFAQRepository
    {
        private readonly string xmlFilePath;
        private List<FAQ> faqList;

        public FAQRepository()
        {
            this.faqList = [];
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;

            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath[..index];
            string pathToFaqXML = $"\\XMLFiles\\FAQitems.xml";
            this.xmlFilePath = pathUntilBin + pathToFaqXML;
            this.LoadFAQsFromXml();
        }

        public List<FAQ> GetFAQList()
        {
            return this.faqList;
        }

        public void AddFAQ(Backend.Models.FAQ newQ)
        {
            this.faqList.Add(newQ);
            this.SaveFAQsToXml();
        }

        public void DeleteFAQ(Backend.Models.FAQ q)
        {
            this.faqList.Remove(q);
            this.SaveFAQsToXml();
        }

        private void LoadFAQsFromXml()
        {
            try
            {
                if (File.Exists(this.xmlFilePath))
                {
                    XmlSerializer serializer = new (typeof(FAQ), new XmlRootAttribute("FAQ"));

                    this.faqList = [];

                    using FileStream fileStream = new (this.xmlFilePath, FileMode.Open);
                    using XmlReader reader = XmlReader.Create(fileStream);
                    while (reader.ReadToFollowing("FAQ"))
                    {
                        FAQ faq = (FAQ)serializer.Deserialize(reader);
                        this.faqList.Add(item: faq);
                    }
                }
                else
                {
                    this.faqList = [];
                }
            }
            catch
            {
            }
        }

        private void SaveFAQsToXml()
        {
            XmlSerializer serializer = new (typeof(List<FAQ>), new XmlRootAttribute("FAQs"));

            using FileStream fileStream = new (this.xmlFilePath, FileMode.Create);
            serializer.Serialize(fileStream, this.faqList);
        }
    }

    internal interface IFAQ
    {
        List<Backend.Models.FAQ> GetFAQList();

        void AddFAQ(Backend.Models.FAQ newQ);

        void DeleteFAQ(Backend.Models.FAQ q);
    }
}
