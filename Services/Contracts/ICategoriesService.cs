using Entities.DTOs;
using Entities.Models;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface ICategoriesService
    {
        public IEnumerable<CategoriesDto> GetAllCategories(bool trackChanges);

        public CategoriesDto? GetOneCategoriesById(int id, bool trackChanges);

        public CategoriesDto? CreateOneCategories(CategoriesCreateDto dto);

        public bool UpdateCategories(int id, CategoriesUpdateDto dto);

        public bool DeleteCategories(int id, bool trackChanges);
        CategoriesUpdateDto? GetCategoriesForUpdate(int id, bool trackChanges);
    }
}