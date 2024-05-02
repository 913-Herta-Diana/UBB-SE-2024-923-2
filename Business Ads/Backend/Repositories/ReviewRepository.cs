using System.Xml.Serialization;
using System.Xml;
using Backend.Models;
using Backend.Controllers;

namespace Backend.Repositories
{
    public class ReviewRepository : INterfaceReview
    {
        private readonly string  xmlFilePath;
        List<ReviewClass> reviewList;
        public ReviewRepository()
        {
            this.reviewList = [];
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;

            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath[..index];
            string pathToReviewsXML = $"\\XMLFiles\\REVIEWitems.xml";
            xmlFilePath = pathUntilBin + pathToReviewsXML;
            LoadFromXml();
        }
        private void LoadFromXml()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                {
                    XmlSerializer serializer = new(typeof(ReviewClass), new XmlRootAttribute("ReviewClass"));

                    reviewList = [];
                    using FileStream fileStream = new(xmlFilePath, FileMode.Open);
                    using XmlReader reader = XmlReader.Create(fileStream);
                    while (reader.ReadToFollowing("ReviewClass"))
                    {
                        ReviewClass review = (ReviewClass)serializer.Deserialize(reader);
                        reviewList.Add(review);
                    }
                }
                else
                {
                    reviewList = [];
                }
            }
            catch { }
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new(typeof(List<ReviewClass>), new XmlRootAttribute("Reviews"));

            using FileStream fileStream = new(xmlFilePath, FileMode.Create);
            serializer.Serialize(fileStream, reviewList);
        }

        public List<ReviewClass> GetReviewList()
        {
            return reviewList;
        }

        public void AddReview(ReviewClass newR)
        {
            reviewList.Add(newR);
            SaveToXml();
        }
    }
    interface INterfaceReview
    {
        public List<ReviewClass> GetReviewList();
        public void AddReview(ReviewClass newR);
    }
}


