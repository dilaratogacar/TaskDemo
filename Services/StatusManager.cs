    using Entities.DTOs;
    using Entities.Models;
    using Repositories.Contracts;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Services
    {
        public class StatusManager : IStatusService
        {
            private readonly IRepositoryManager _manager;
            public StatusManager(IRepositoryManager manager)
            {
                _manager = manager;
            }
            public StatusDto? CreateOneStatus(StatusCreateDto status)
            {
                var entity = new Status
                {
                    Title = status.Title,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System"
                };

            _manager.Status.CreateOneStatus(entity);
            _manager.Save();

            var created = _manager.Status.GetOneStatusById(entity.Id, trackChanges: false);

            if (created is null)
                return null;

            return new StatusDto
            {
                Id = created.Id,
                Title = created.Title,
            };
        }
            public bool DeleteStatus(int id, bool trackChanges)
            {
                var entity = _manager.Status.GetOneStatusById(id, trackChanges);
                if (entity is null)
                    return false;
                _manager.Status.DeleteOneStatus(entity);
                _manager.Save();

                return true;

            }

            public IEnumerable<StatusDto> GetAllStatus(bool trackChanges)
            {
                var statuses = _manager.Status.GetAllStatus(trackChanges);

                return statuses.Select(status => new StatusDto
                {
                    Id = status.Id,
                    Title = status.Title
                });
            }

            public StatusDto? GetOneStatusById(int id, bool trackChanges)
            {
                var status = _manager.Status.GetOneStatusById(id, trackChanges);

                if (status is null)
                    return null;

                return new StatusDto
                {
                    Id = status.Id,
                    Title = status.Title
                };
            }               
                
            

            public bool UpdateStatus(int id, StatusUpdateDto dto)
            {
                var entity = _manager.Status.GetOneStatusById(id, trackChanges: true);

                if (entity is null)
                    return false;
                entity.Title = dto.Title;

                _manager.Save();
                return true;
            }

            public StatusUpdateDto? GetStatusForUpdate(int id, bool trackChanges)
            {
                var status = _manager.Status.GetOneStatusById(id, trackChanges);

                if (status is null)
                    return null;

                return new StatusUpdateDto
                {
                    Title = status.Title,

                };
            }


        }
    }
