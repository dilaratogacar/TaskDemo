using Entities.DTOs;
using Entities.Models;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface ITaskService
    {
        public IEnumerable<TaskDto> GetAllTasks(bool trackChanges);

        public TaskDto? GetOneTaskById(int id, bool trackChanges);

        public TaskDto? CreateOneTask(TaskCreateDto task);

        public bool UpdateTask(int id, TaskUpdateDto dto);

        public bool DeleteTask(int id, bool trackChanges);
        TaskUpdateDto? GetTaskForUpdate(int id, bool trackChanges);
    }
}