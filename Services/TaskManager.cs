    using Entities.DTOs;
    using Entities.Models;
    using Repositories.Contracts;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Services
    {
        public class TaskManager : ITaskService
        {
            private readonly IRepositoryManager _manager;
            public TaskManager(IRepositoryManager manager)
            {
                _manager = manager;
            }
            public TaskDto? CreateOneTask(TaskCreateDto task)
            {
                var entity = new Tasks
                {
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    StatusID = task.StatusID,
                    CategoriesId = task.CategoriesId,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System"
                };

            _manager.Task.CreateOneTask(entity);
            _manager.Save();

            var created = _manager.Task.GetOneTaskById(entity.Id, trackChanges: false);

            if (created is null)
                return null;

            return new TaskDto
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
                Priority = created.Priority,
                StatusName = created.Status.Title,
                CategoryName = created.Categories.Title,
                StartDate = created.StartDate,
                EndDate = created.EndDate
            };
        }
            public bool DeleteTask(int id, bool trackChanges)
            {
                var entity = _manager.Task.GetOneTaskById(id, trackChanges);
                if (entity is null)
                    return false;
                _manager.Task.DeleteOneTask(entity);
                _manager.Save();

                return true;

            }

            public IEnumerable<TaskDto> GetAllTasks(bool trackChanges)
            {
                var tasks = _manager.Task.GetAllTasks(trackChanges);

                return tasks.Select(task => new TaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    StatusName = task.Status.Title,
                    CategoryName = task.Categories.Title,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate
                });
            }

            public TaskDto? GetOneTaskById(int id, bool trackChanges)
            {
                var task = _manager.Task.GetOneTaskById(id, trackChanges);

                if (task is null)
                    return null;

                return new TaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    StatusName = task.Status.Title,
                    CategoryName = task.Categories.Title,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                };
            }

            public bool UpdateTask(int id, TaskUpdateDto dto)
            {
                var entity = _manager.Task.GetOneTaskById(id, trackChanges: true);

                if (entity is null)
                    return false;
                entity.Title = dto.Title;
                entity.Description = dto.Description;
                entity.Priority = dto.Priority;
                entity.StatusID = dto.StatusID;
                entity.CategoriesId = dto.CategoriesId;
                entity.StartDate = dto.StartDate;
                entity.EndDate = dto.EndDate;

                _manager.Save();
                return true;
            }

            public TaskUpdateDto? GetTaskForUpdate(int id, bool trackChanges)
            {
                var task = _manager.Task.GetOneTaskById(id, trackChanges);

                if (task is null)
                    return null;

                return new TaskUpdateDto
                {
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    StatusID = task.StatusID,
                    CategoriesId = task.CategoriesId,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate
                };
            }


        }
    }
