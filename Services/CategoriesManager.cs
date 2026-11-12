    using Entities.DTOs;
    using Entities.Models;
    using Repositories.Contracts;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Services
    {
        public class CategoriesManager : ICategoriesService
        {
            private readonly IRepositoryManager _manager;
            public CategoriesManager(IRepositoryManager manager)
            {
                _manager = manager;
            }
            public CategoriesDto? CreateOneCategories(CategoriesCreateDto categories)
            {
                var entity = new Categories
                {
                    Title = categories.Title,
                    Description = categories.Description,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System"
                };

            _manager.Categories.CreateOneCategories(entity);
            _manager.Save();

            var created = _manager.Categories.GetOneCategoriesById(entity.Id, trackChanges: false);

            if (created is null)
                return null;

            return new CategoriesDto
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
            };
        }
            public bool DeleteCategories(int id, bool trackChanges)
            {
                var entity = _manager.Categories.GetOneCategoriesById(id, trackChanges);
                if (entity is null)
                    return false;
                _manager.Categories.DeleteOneCategories(entity);
                _manager.Save();

                return true;

            }

            public IEnumerable<CategoriesDto> GetAllCategories(bool trackChanges)
            {
                var categories = _manager.Categories.GetAllCategories(trackChanges);

                return categories.Select(categories => new CategoriesDto
                {
                    Id = categories.Id,
                    Title = categories.Title,
                    Description = categories.Description
                });
            }

            public CategoriesDto? GetOneCategoriesById(int id, bool trackChanges)
            {
                var categories = _manager.Categories.GetOneCategoriesById(id, trackChanges);

                if (categories is null)
                    return null;

                return new CategoriesDto
                {
                    Id = categories.Id,
                    Title = categories.Title,
                    Description = categories.Description
                };
            }               
                
            

            public bool UpdateCategories(int id, CategoriesUpdateDto dto)
            {
                var entity = _manager.Categories.GetOneCategoriesById(id, trackChanges: true);

                if (entity is null)
                    return false;
                entity.Title = dto.Title;
                entity.Description = dto.Description;

                _manager.Save();
                return true;
            }

            public CategoriesUpdateDto? GetCategoriesForUpdate(int id, bool trackChanges)
            {
                var categories = _manager.Categories.GetOneCategoriesById(id, trackChanges);

                if (categories is null)
                    return null;

                return new CategoriesUpdateDto
                {
                    Title = categories.Title,
                    Description = categories.Description,
                };
            }


        }
    }
