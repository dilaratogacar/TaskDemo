using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EFCore
{
    public class CategoriesRepository : RepositoryBase<Categories>, ICategoriesRepository   
    {
        public CategoriesRepository(RepositoryContext context) : base(context)
        {

        }

        public void DeleteOneCategories(Categories categories) => Delete(categories);

        public void CreateOneCategories(Categories categories) => Create(categories);


        public IEnumerable<Categories> GetAllCategories(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Include(a => a.Tasks)  // ← bunu ekleyin
                .ToList();
        }

        public Categories? GetOneCategoriesById(int id, bool trackChanges)
            => FindByCondition(b => b.Id.Equals(id), trackChanges)
                .Include(a => a.Tasks)
                .SingleOrDefault();
        public void UpdateOneCategory(Categories categories) => Update(categories);
    }
}
