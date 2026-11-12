
using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITaskRepository : IRepositoryBase<Tasks>
    {
        IEnumerable<Tasks> GetAllTasks(bool trackChanges);

        Tasks? GetOneTaskById(int id, bool trackChanges);

        void CreateOneTask(Tasks task);

        void DeleteOneTask(Tasks task);
    }
}
