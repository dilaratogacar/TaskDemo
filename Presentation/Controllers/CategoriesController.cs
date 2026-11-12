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
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _manager.CategoriesService
                .GetAllCategories(trackChanges: false)
                .ToList();

            return Ok(categories);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneCategories([FromRoute(Name = "id")] int id)
        {
            var category = _manager.CategoriesService
                .GetOneCategoriesById(id, trackChanges: false);

            if (category is null)
                return NotFound();

            return Ok(category);
        }
        [HttpPost]
        public IActionResult CreateOneCategories([FromBody] CategoriesCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _manager.CategoriesService.CreateOneCategories(dto);

            if (category is null)
                return BadRequest();

            return StatusCode(201, category);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateOneCategory([FromRoute(Name = "id")] int id,
            [FromBody] CategoriesUpdateDto dto)
        {
            var updated = _manager.CategoriesService.UpdateCategories(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();

        }
        [HttpDelete("{id:int}")]

        public IActionResult DeleteOneCategories(int id)
        {
            var deleted = _manager.CategoriesService.DeleteCategories(
                id,
                trackChanges: false
            );

            if (!deleted)
                return NotFound();

            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneCategory(
            int id,
            [FromBody] JsonPatchDocument<CategoriesUpdateDto> categoryPatch)
        {
            if (categoryPatch is null)
                return BadRequest();

            var dto = _manager.CategoriesService
                .GetCategoriesForUpdate(id, trackChanges: true);

            if (dto is null)
                return NotFound();

            categoryPatch.ApplyTo(dto, error =>
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

            var updated = _manager.CategoriesService.UpdateCategories(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

    }
}
