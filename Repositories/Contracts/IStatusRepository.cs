
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IStatusRepository : IRepositoryBase<Status>
    {
        IEnumerable<Status> GetAllStatus(bool trackChanges);

        Status? GetOneStatusById(int id, bool trackChanges);

        void CreateOneStatus(Status status);

        void DeleteOneStatus(Status status);
    }
}
