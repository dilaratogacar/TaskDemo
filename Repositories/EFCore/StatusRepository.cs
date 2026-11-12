using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.EFCore
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(RepositoryContext context) : base(context)
        {

        }

        public void DeleteOneStatus(Status status) => Delete(status);

        public void CreateOneStatus(Status status) => Create(status);


        public IEnumerable<Status> GetAllStatus(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Include(a => a.Tasks)  // ← bunu ekleyin
                .ToList();
        }

        public Status? GetOneStatusById(int id, bool trackChanges)
            => FindByCondition(b => b.Id.Equals(id), trackChanges)
                .Include(a => a.Tasks)
                .SingleOrDefault();
        public void UpdateOneStatus(Status status) => Update(status);
    }
}
