using System.Xml.Serialization;
using System.Xml;
using Backend.Models;

namespace Backend.Repositories
{
    public class TODORepository : INterfaceToDoRepository
    {
        private List<TODOClass> todosList;
        private readonly string xmlFilePath;
        private static int _lastId = 0;

        public TODORepository() 
        { 
            todosList = [];
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;


            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath[..index];
            string pathToToDoXML = $"\\XMLFiles\\TODOitems.xml";
            xmlFilePath = pathUntilBin + pathToToDoXML;
            LoadFromXml();
        }

        
        public void AddingTODO(TODOClass newTODO)
        {
            newTODO.ID = _lastId++;
            todosList.Add(newTODO);
            SaveToXml();
        }

        public void RemovingTODO(TODOClass newTODO)
        {
            todosList.Remove(newTODO);
            SaveToXml();

        }

        public List<TODOClass> GetTODOS()
        {
            return todosList;
        }
        private void LoadFromXml()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                {
                    XmlSerializer serializer = new(typeof(TODOClass), new XmlRootAttribute("TODOClass"));

                    todosList = [];

                    using FileStream fileStream = new(xmlFilePath, FileMode.Open);
                    using XmlReader reader = XmlReader.Create(fileStream);
                    while (reader.ReadToFollowing("TODOClass"))
                    {
                        TODOClass todo = (TODOClass)serializer.Deserialize(reader);
                        todo.ID = _lastId++;
                        todosList.Add(todo);
                    }
                }
                else
                {
                    todosList = [];
                }
            }
            catch { }
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new(typeof(List<TODOClass>), new XmlRootAttribute("TODOs"));

            using FileStream fileStream = new(xmlFilePath, FileMode.Create);
            serializer.Serialize(fileStream, todosList);
        }


    }

    interface INterfaceToDoRepository
    {
        public void AddingTODO(TODOClass newTODO);
        public void RemovingTODO(TODOClass newTODO);
        public List<TODOClass> GetTODOS();
    }
}
