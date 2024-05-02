using System.Xml.Serialization;
using System.Xml;
using Backend.Models;

namespace Backend.Repositories
{
    public class TODORepository : InterfaceToDoRepository
    {
        private List<TODOClass> todosList;
        private readonly string xmlFilePath;
        private static int _lastId = 0;

        public TODORepository() 
        { 
            todosList = new List<TODOClass>();
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;


            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath.Substring(0, index);
            string pathToToDoXML = $"\\XMLFiles\\TODOitems.xml";
            xmlFilePath = pathUntilBin + pathToToDoXML;
            LoadFromXml();
        }

        private void LoadFromXml()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                {
                    XmlSerializer serializer = new(typeof(TODOClass), new XmlRootAttribute("TODOClass"));

                    todosList = new List<TODOClass>();

                    using (FileStream fileStream = new(xmlFilePath, FileMode.Open))
                    using (XmlReader reader = XmlReader.Create(fileStream))
                    {
                        while (reader.ReadToFollowing("TODOClass"))
                        {
                            TODOClass todo = (TODOClass)serializer.Deserialize(reader);
                            todo.ID = _lastId++;
                            todosList.Add(todo);
                        }
                    }
                }
                else
                {
                    todosList = new List<TODOClass>();
                }
            }
            catch { }
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new(typeof(List<TODOClass>), new XmlRootAttribute("TODOs"));

            using (FileStream fileStream = new(xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, todosList);
            }
        }
        public void addingTODO(TODOClass newTODO)
        {
            newTODO.ID = _lastId++;
            todosList.Add(newTODO);
            SaveToXml();
        }
        public void removingTODO(TODOClass newTODO)
        {
            todosList.Remove(newTODO);
            SaveToXml();

        }

        public List<TODOClass> getTODOS()
        {
            return todosList;
        }



    }

    interface InterfaceToDoRepository
    {
        public void addingTODO(TODOClass newTODO);
        public void removingTODO(TODOClass newTODO);
        public List<TODOClass> getTODOS();
    }
}
