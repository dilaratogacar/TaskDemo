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
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public StatusController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public IActionResult GetAllStatus()
        {
            var status = _manager.StatusService
                .GetAllStatus(trackChanges: false)
                .ToList();

            return Ok(status);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneStatus([FromRoute(Name = "id")] int id)
        {
            var status = _manager.StatusService
                .GetOneStatusById(id, trackChanges: false);

            if (status is null)
                return NotFound();

            return Ok(status);
        }
        [HttpPost]
        public IActionResult CreateOneStatus([FromBody] StatusCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var status = _manager.StatusService.CreateOneStatus(dto);

            if (status is null)
                return BadRequest();

            return StatusCode(201, status);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateOneStatus([FromRoute(Name = "id")] int id,
            [FromBody] StatusUpdateDto dto)
        {
            var updated = _manager.StatusService.UpdateStatus(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();

        }
        [HttpDelete("{id:int}")]

        public IActionResult DeleteOneStatus(int id)
        {
            var deleted = _manager.StatusService.DeleteStatus(
                id,
                trackChanges: false
            );

            if (!deleted)
                return NotFound();

            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneStatus(
            int id,
            [FromBody] JsonPatchDocument<StatusUpdateDto> statusPatch)
        {
            if (statusPatch is null)
                return BadRequest();

            var dto = _manager.StatusService
                .GetStatusForUpdate(id, trackChanges: true);

            if (dto is null)
                return NotFound();

            statusPatch.ApplyTo(dto, error =>
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

            var updated = _manager.StatusService.UpdateStatus(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

    }
}
