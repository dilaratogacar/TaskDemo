using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EFCore
{
    public class TaskRepository : RepositoryBase<Tasks>, ITaskRepository
    {
        public TaskRepository(RepositoryContext context) : base(context)
        {

        }

        public void DeleteOneTask(Tasks task) => Delete(task);

        public void CreateOneTask(Tasks task) => Create(task);


        public IEnumerable<Tasks> GetAllTasks(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Include(a => a.Categories)  // ← bunu ekleyin
                .Include(a => a.Status)  // ← bunu ekleyin
                .ToList();
        }

        public Tasks? GetOneTaskById(int id, bool trackChanges)
            => FindByCondition(b => b.Id.Equals(id), trackChanges)
                .Include(a => a.Categories)
                .Include(a => a.Status)
                .SingleOrDefault();
        public void UpdateOneTask(Tasks author) => Update(author);
    }
}
