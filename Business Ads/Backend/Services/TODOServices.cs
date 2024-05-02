using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class TODOServices : IServicesTODO
    {
        private static readonly TODOServices instance = new();
        private readonly TODORepository repository;

        private TODOServices()
        {
            repository = new TODORepository();
        }

        public static TODOServices Instance
        {
            get { return instance; }
        }

        public List<TODOClass> GetTODOS()
        {
            return repository.GetTODOS();
        }

        public void AddTODO(TODOClass obj)
        {
            repository.AddingTODO(obj);
        }

        public void RemoveTODO(int id)
        {
            TODOClass todoToRemove = GetTODOS().FirstOrDefault(todo => todo.ID == id);

            if (todoToRemove != null)
            {
                repository.RemovingTODO(todoToRemove);
            }
        }
    }

    public interface IServicesTODO
    {
        List<TODOClass> GetTODOS();
        void AddTODO(TODOClass obj);
        void RemoveTODO(int id);
    }
}
