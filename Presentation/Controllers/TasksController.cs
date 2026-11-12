using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public TasksController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _manager.TaskService
                .GetAllTasks(trackChanges: false)
                .ToList();

            return Ok(tasks);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneTask([FromRoute(Name = "id")] int id)
        {
            var task = _manager.TaskService
                .GetOneTaskById(id, trackChanges: false);

            if (task is null)
                return NotFound();

            return Ok(task);
        }
        [HttpPost]
        public IActionResult CreateOneTask([FromBody] TaskCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = _manager.TaskService.CreateOneTask(dto);

            if (task is null)
                return BadRequest();

            return StatusCode(201, task);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateOneTask([FromRoute(Name = "id")] int id,
            [FromBody] TaskUpdateDto book)
        {
            var updated = _manager.TaskService.UpdateTask(id, book);

            if (!updated)
                return NotFound();

            return NoContent();

        }
        [HttpDelete("{id:int}")]

        public IActionResult DeleteOneTask(int id)
        {
            var deleted = _manager.TaskService.DeleteTask(
                id,
                trackChanges: false
            );

            if (!deleted)
                return NotFound();

            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneTask(
            int id,
            [FromBody] JsonPatchDocument<TaskUpdateDto> taskPatch)
        {
            if (taskPatch is null)
                return BadRequest();

            var dto = _manager.TaskService
                .GetTaskForUpdate(id, trackChanges: true);

            if (dto is null)
                return NotFound();

            taskPatch.ApplyTo(dto, error =>
            {
                ModelState.AddModelError(
                    error.AffectedObject.GetType().Name,
                    error.ErrorMessage
                );
            });

            if (!TryValidateModel(dto))
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _manager.TaskService.UpdateTask(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

    }
}
