
using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoriesRepository : IRepositoryBase<Categories>
    {
        IEnumerable<Categories> GetAllCategories(bool trackChanges);

        Categories? GetOneCategoriesById(int id, bool trackChanges);

        void CreateOneCategories(Categories categories);

        void DeleteOneCategories(Categories categories);
    }
}
