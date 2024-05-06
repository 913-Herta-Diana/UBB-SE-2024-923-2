using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Backend.Models;
using Backend.Services;

namespace Backend.Repositories
{
    public class FAQRepository : IFAQRepository
    {
        private readonly string xmlFilePath;
        private readonly IFileIOService fileIOService;
        private List<FAQ> faqList;

        public FAQRepository()
        {
            this.faqList = new List<FAQ>();
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

        public void AddFAQ(Backend.Models.FAQ newQuestion)
        {
            this.faqList.Add(newQuestion);
            this.SaveFAQsToXml();
        }

        public void DeleteFAQ(Backend.Models.FAQ question)
        {
            this.faqList.Remove(question);
            this.SaveFAQsToXml();
        }

        private void LoadFAQsFromXml()
        {
            this.faqList = fileIOService.LoadFromXml(xmlFilePath);
        }

        private void SaveFAQsToXml()
        {
            fileIOService.SaveToXml(faqList, xmlFilePath);
        }
    }
}
