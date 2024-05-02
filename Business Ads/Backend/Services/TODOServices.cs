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

        public List<TODOClass> getTODOS()
        {
            return repository.GetTODOS();
        }

        public void addTODO(TODOClass obj)
        {
            repository.AddingTODO(obj);
        }

        public void removeTODO(int id)
        {
            TODOClass todoToRemove = getTODOS().FirstOrDefault(todo => todo.ID == id);

            if (todoToRemove != null)
            {
                repository.RemovingTODO(todoToRemove);
            }
        }
    }

    public interface IServicesTODO
    {
        List<TODOClass> getTODOS();
        void addTODO(TODOClass obj);
        void removeTODO(int id);
    }
}
