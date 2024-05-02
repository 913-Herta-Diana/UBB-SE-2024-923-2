namespace Backend.Services
{
    using Backend.Models;
    using Backend.Repositories;

    public class TODOServices : IServicesTODO
    {
        private static readonly TODOServices TheInstance = new ();
        private readonly TODORepository repository;

        private TODOServices()
        {
            repository = new TODORepository();
        }

        public static TODOServices Instance
        {
            get { return TheInstance; }
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
